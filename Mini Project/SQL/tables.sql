CREATE DATABASE TrainReservationDB;
GO
USE TrainReservationDB;
GO




CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin','User'))
);




CREATE TABLE Train (
    TrainNo INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,

    AC1_Available INT NOT NULL CHECK (AC1_Available >= 0),
    AC3_Available INT NOT NULL CHECK (AC3_Available >= 0),
    Sleeper_Available INT NOT NULL CHECK (Sleeper_Available >= 0),

    TotalSeats INT NOT NULL CHECK (TotalSeats > 0),

    IsDeleted BIT DEFAULT 0,

    
 CHECK (
        AC1_Available + AC3_Available + Sleeper_Available <= TotalSeats
    )

);



CREATE TABLE Station (
    StationId INT IDENTITY PRIMARY KEY,
    StationName VARCHAR(50) NOT NULL UNIQUE
);


CREATE TABLE ClassFare (
    Class VARCHAR(10) PRIMARY KEY CHECK (Class IN ('AC1','AC3','Sleeper')),
    RatePerKM DECIMAL(10,2) NOT NULL CHECK (RatePerKM > 0)
);


CREATE   TABLE TrainRoute (
    RouteId INT IDENTITY PRIMARY KEY,
    TrainNo INT NOT NULL,
    StationId INT NOT NULL,

    StopOrder INT NOT NULL CHECK (StopOrder > 0),
    DistanceFromStart INT NOT NULL CHECK (DistanceFromStart >= 0),

    ArrivalTime varchar(10) NULL,
    DepartureTime varchar(10) NULL,

    CONSTRAINT FK_TrainRoute_Train FOREIGN KEY (TrainNo)
        REFERENCES Train(TrainNo),

    CONSTRAINT FK_TrainRoute_Station FOREIGN KEY (StationId)
        REFERENCES Station(StationId)
);




CREATE TABLE Booking (
    BookingId INT IDENTITY PRIMARY KEY,

    TrainNo INT NOT NULL,
    FromStation int NOT NULL,
    ToStation int NOT NULL,

    TravelDate DATE NOT NULL ,
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),

    BookingDate DATE DEFAULT GETDATE(),

    CONSTRAINT CHK_Station CHECK (FromStation <> ToStation),

    CONSTRAINT FK_Booking_Train FOREIGN KEY (TrainNo)
        REFERENCES Train(TrainNo),

    CONSTRAINT FK_Booking_FromStation FOREIGN KEY (FromStation)
        REFERENCES Station(StationId),

    CONSTRAINT FK_Booking_ToStation FOREIGN KEY (ToStation)
        REFERENCES Station(StationId)
);



CREATE TABLE PassengerDetails (
    PassengerId INT IDENTITY PRIMARY KEY,

    BookingId INT NOT NULL,
    PassengerName VARCHAR(50) NOT NULL,

    Class VARCHAR(10) NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),

    SeatNo VARCHAR(10) NOT NULL,

    IsCancelled BIT DEFAULT 0,

    CONSTRAINT FK_Passenger_Booking FOREIGN KEY (BookingId)
        REFERENCES Booking(BookingId),

    CONSTRAINT FK_Passenger_Class FOREIGN KEY (Class)
        REFERENCES ClassFare(Class)
);







CREATE TABLE Cancellation (
    CId INT IDENTITY PRIMARY KEY,

    PassengerId INT NOT NULL,
    RefundAmount DECIMAL(10,2) NOT NULL CHECK (RefundAmount >= 0),

    CancelDate DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Cancel_Passenger FOREIGN KEY (PassengerId)
        REFERENCES PassengerDetails(PassengerId)
);





CREATE TABLE Payment (
    PaymentId INT IDENTITY PRIMARY KEY,

    BookingId INT NOT NULL,
    PassengerId INT NOT NULL,

    SeatNo VARCHAR(10),

    PaymentType VARCHAR(20) NOT NULL CHECK (PaymentType IN ('CASH','UPI')),

    PaymentStatus VARCHAR(20) NOT NULL
        CHECK (PaymentStatus IN ('PAID','REFUNDED')),

    Amount DECIMAL(10,2) NOT NULL CHECK (Amount >= 0),

    PaymentDate DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Payment_Booking FOREIGN KEY (BookingId)
        REFERENCES Booking(BookingId),

    CONSTRAINT FK_Payment_Passenger FOREIGN KEY (PassengerId)
        REFERENCES PassengerDetails(PassengerId)
);




INSERT INTO ClassFare VALUES
('AC1',5.0),
('AC3',3.0),
('Sleeper',1.5);





INSERT INTO Users VALUES ('Admin','Admin@123','Admin');

