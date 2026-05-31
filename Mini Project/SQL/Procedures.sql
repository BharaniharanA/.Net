--1)user login 

CREATE PROCEDURE UserLogin
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    SELECT Role
    FROM Users
    WHERE Username = @Username AND Password = @Password;
END


--2)Add user

CREATE PROCEDURE AddUser
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    INSERT INTO Users (Username, Password, Role)
    VALUES (@Username, @Password, 'User');
END


--3)add train (admin)

CREATE or alter PROCEDURE AddTrain
    @Role VARCHAR(20),
    @TrainNo INT,
    @Name VARCHAR(50),
    @AC1 INT,
    @AC3 INT,
    @Sleeper INT,
    @Total INT
AS
BEGIN
    IF @Role <> 'Admin'
    BEGIN
        PRINT 'ACCESS DENIED';
        RETURN;
    END

    INSERT INTO Train
    VALUES (@TrainNo, @Name, @AC1, @AC3, @Sleeper, @Total, 0);
END


--4)add station (admin)

CREATE or alter PROCEDURE AddStation
    @Role VARCHAR(20),
    @StationName VARCHAR(50)
AS
BEGIN
    IF @Role <> 'Admin'
    BEGIN
        PRINT 'ACCESS DENIED';
        RETURN;
    END

    INSERT INTO Station (StationName)
    VALUES (@StationName);
END


--5)ADD TRAIN ROUTE (admin) 


CREATE or alter PROCEDURE AddTrainRoute
    @Role VARCHAR(20),
    @TrainNo INT,
    @StationId INT,
    @Order INT,
    @Distance INT,
    @Arr varchar(10),
    @Dep varchar(10)
AS
BEGIN
    IF @Role <> 'Admin'
    BEGIN
        PRINT 'ACCESS DENIED';
        RETURN;
    END

    INSERT INTO TrainRoute
    VALUES (@TrainNo, @StationId, @Order, @Distance, @Arr, @Dep);
END


--6) SOFT DELETE TRAIN (25% RULE)(admin)


CREATE or alter PROCEDURE SoftDeleteTrain
    @Role VARCHAR(20),
    @TrainNo INT
AS
BEGIN
    IF @Role <> 'Admin'
    BEGIN
        PRINT 'ACCESS DENIED';
        RETURN;
    END

    DECLARE @Total INT, @Available INT, @Booked INT

    SELECT @Total = TotalSeats,@Available = AC1_Available + AC3_Available + Sleeper_Available
    FROM Train
    WHERE TrainNo = @TrainNo

    SET @Booked = @Total - @Available

    IF (@Booked * 100.0 / @Total) >= 25
    BEGIN
        PRINT 'CANNOT DELETE TRAIN (MORE THAN 25% BOOKED)';
        RETURN;
    END

    UPDATE Train
    SET IsDeleted = 1
    WHERE TrainNo = @TrainNo;
END



--7)get available train

CREATE PROCEDURE GetAvailableTrains
AS
BEGIN
    SELECT * FROM Train WHERE IsDeleted = 0;
END



--8) SEARCH TRAIN BY ROUTE


CREATE or alter PROCEDURE SearchTrainByRoute
    @FromStation int,
    @ToStation int
AS
BEGIN
    SELECT DISTINCT T.*
    FROM Train T
    JOIN TrainRoute TR1 ON T.TrainNo = TR1.TrainNo
    JOIN TrainRoute TR2 ON T.TrainNo = TR2.TrainNo
    WHERE TR1.StationId = @FromStation
      AND TR2.StationId = @ToStation
      AND TR1.StopOrder < TR2.StopOrder
      AND T.IsDeleted = 0;
END


--9)CALCULATE FARE


CREATE PROCEDURE CalculateFare
    @TrainNo INT,
    @FromStation INT,
    @ToStation INT,
    @Class VARCHAR(10)
AS
BEGIN
    DECLARE @FromDist INT, @ToDist INT, @Rate DECIMAL(10,2)

    SELECT @FromDist = DistanceFromStart
    FROM TrainRoute
    WHERE TrainNo = @TrainNo AND StationId = @FromStation

    SELECT @ToDist = DistanceFromStart
    FROM TrainRoute
    WHERE TrainNo = @TrainNo AND StationId = @ToStation

    SELECT @Rate = RatePerKM
    FROM ClassFare
    WHERE Class = @Class

    SELECT (@ToDist - @FromDist) * @Rate AS Fare;
END


--10)CREATE BOOKING

CREATE PROCEDURE CreateBooking
    @TrainNo INT,
    @FromStation INT,
    @ToStation INT,
    @Amount DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Booking
    VALUES (@TrainNo, @FromStation, @ToStation, GETDATE(), @Amount, GETDATE());

    SELECT SCOPE_IDENTITY() AS BookingId;
END


--11) ADD PASSENGERS
CREATE OR ALTER PROCEDURE AddPassengers
    @BookingId INT,
    @Name VARCHAR(50),
    @Class VARCHAR(10),
    @Price DECIMAL(10,2)
AS
BEGIN
    DECLARE @SeatNo VARCHAR(10)

    -- reuse a cancelled seat
    SELECT TOP 1 @SeatNo = SeatNo
    FROM PassengerDetails
    WHERE Class = @Class AND IsCancelled = 1
    ORDER BY PassengerId

    IF @SeatNo IS NOT NULL
    BEGIN
        -- Reuse cancelled seat
        UPDATE PassengerDetails
        SET IsCancelled = 0,
            BookingId = @BookingId,
            PassengerName = @Name,
            Price = @Price
        WHERE SeatNo = @SeatNo
    END
    ELSE
    BEGIN
        -- No cancelled seat, assign new seat
        DECLARE @Count INT
        SELECT @Count = COUNT(*)
        FROM PassengerDetails
        WHERE Class = @Class

        SET @SeatNo = @Class + '-' + CAST(@Count + 1 AS VARCHAR)

        INSERT INTO PassengerDetails
        VALUES (@BookingId, @Name, @Class, @Price, @SeatNo, 0)
    END
END


--12)GET BOOKING DETAILS


CREATE PROCEDURE GetBookingFullDetails
    @BookingId INT
AS
BEGIN
    SELECT B.*, T.Name, P.*
    FROM Booking B
    JOIN Train T ON B.TrainNo = T.TrainNo
    JOIN PassengerDetails P ON B.BookingId = P.BookingId
    WHERE B.BookingId = @BookingId;
END


--13)CANCEL PASSENGER

CREATE or alter PROCEDURE CancelPassenger
    @PassengerId INT
AS
BEGIN

IF EXISTS (
        SELECT 1 FROM PassengerDetails 
        WHERE PassengerId = @PassengerId AND IsCancelled = 1
    )
    BEGIN
        PRINT 'Passenger already cancelled';
        RETURN;
    END

    DECLARE @TrainNo INT, @Class VARCHAR(10), @Price DECIMAL(10,2)

    SELECT @TrainNo = B.TrainNo,
           @Class = P.Class,
           @Price = P.Price
    FROM PassengerDetails P
    JOIN Booking B ON P.BookingId = B.BookingId
    WHERE PassengerId = @PassengerId

    UPDATE PassengerDetails
    SET IsCancelled = 1
    WHERE PassengerId = @PassengerId

    INSERT INTO Cancellation VALUES(@PassengerId, @Price * 0.9, GETDATE())

    IF @Class = 'AC1'
        UPDATE Train SET AC1_Available = AC1_Available + 1 WHERE TrainNo = @TrainNo
    ELSE IF @Class = 'AC3'
        UPDATE Train SET AC3_Available = AC3_Available + 1 WHERE TrainNo = @TrainNo
    ELSE
        UPDATE Train SET Sleeper_Available = Sleeper_Available + 1 WHERE TrainNo = @TrainNo
END


--14) MAKE PAYMENT

CREATE PROCEDURE MakePayment
    @BookingId INT,
    @PassengerId INT,
    @SeatNo VARCHAR(10),
    @Type VARCHAR(20),
    @Amount DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Payment
    VALUES (@BookingId, @PassengerId, @SeatNo, @Type, 'PAID', @Amount, GETDATE());
END


--15)PROCESS REFUND

CREATE or alter PROCEDURE ProcessRefund
    @PassengerId INT

AS
BEGIN
    UPDATE Payment
    SET PaymentStatus = 'REFUNDED'
    WHERE PassengerId = @PassengerId
END


--16) get all details (admin)

CREATE PROCEDURE GetAllData
    @Role VARCHAR(20)
AS
BEGIN
    IF @Role <> 'Admin'
    BEGIN
        PRINT 'ACCESS DENIED';
        RETURN;
    END

    SELECT * FROM Users;
    SELECT * FROM Train;
    SELECT * FROM Station;
    SELECT * FROM TrainRoute;
    SELECT * FROM Booking;
    SELECT * FROM PassengerDetails;
    SELECT * FROM Payment;
    SELECT * FROM Cancellation;
END




--17) seat update
CREATE PROCEDURE UpdateSeatOnBooking
    @TrainNo INT,
    @Class VARCHAR(10)
AS
BEGIN
    -- Reduce seat based on class
    IF @Class = 'AC1'
    BEGIN
        UPDATE Train
        SET AC1_Available = AC1_Available - 1
        WHERE TrainNo = @TrainNo;
    END
    ELSE IF @Class = 'AC3'
    BEGIN
        UPDATE Train
        SET AC3_Available = AC3_Available - 1
        WHERE TrainNo = @TrainNo;
    END
    ELSE IF @Class = 'Sleeper'
    BEGIN
        UPDATE Train
        SET Sleeper_Available = Sleeper_Available - 1
        WHERE TrainNo = @TrainNo;
    END
END


