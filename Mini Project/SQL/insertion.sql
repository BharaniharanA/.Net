INSERT INTO Station (StationName) VALUES
('Chennai'),
('Vellore'),
('Katpadi'),
('Salem'),
('Erode'),
('Coimbatore'),
('Madurai'),
('Trichy'),
('Villupuram'),
('Bangalore');

INSERT INTO Train
(TrainNo, Name, AC1_Available, AC3_Available, Sleeper_Available, TotalSeats)
VALUES
(12601, 'Chennai Express', 20, 40, 140, 200),
(12602, 'Coimbatore Superfast', 15, 35, 100, 150),
(12603, 'Madurai Mail', 10, 30, 110, 150),
(12604, 'Bangalore Intercity', 12, 38, 100, 150);

INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12601,1,1,0,NULL,'06:00'),
(12601,2,2,140,'08:00','08:05'),
(12601,4,3,340,'11:00','11:05'),
(12601,5,4,410,'12:15','12:20'),
(12601,6,5,500,'14:00',NULL);

INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12602,6,1,0,NULL,'07:00'),
(12602,5,2,90,'08:15','08:20'),
(12602,4,3,160,'09:30','09:35'),
(12602,1,4,500,'14:00',NULL)

INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12603,7,1,0,NULL,'08:00'),
(12603,8,2,130,'10:00','10:05'),
(12603,9,3,250,'12:00','12:05'),
(12603,1,4,450,'15:00',NULL);


INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12604,10,1,0,NULL,'06:30'),
(12604,2,2,180,'09:00','09:05'),
(12604,1,3,350,'11:30',NULL);


--return train
INSERT INTO Train
(TrainNo, Name, AC1_Available, AC3_Available, Sleeper_Available, TotalSeats)
VALUES
(12611, 'Coimbatore Chennai Express', 20, 40, 140, 200),
(12612, 'Chennai Coimbatore Superfast', 15, 35, 100, 150),
(12613, 'Chennai Madurai Mail', 10, 30, 110, 150),
(12614, 'Chennai Bangalore Intercity', 12, 38, 100, 150);

INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12611,6,1,0,NULL,'15:00'),
(12611,5,2,90,'16:20','16:25'),
(12611,4,3,160,'17:40','17:45'),
(12611,2,4,360,'21:00','21:05'),
(12611,1,5,500,'23:30',NULL);

INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12612,1,1,0,NULL,'16:00'),
(12612,4,2,340,'20:00','20:05'),
(12612,5,3,410,'21:15','21:20'),
(12612,6,4,500,'23:00',NULL);

INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12613,1,1,0,NULL,'17:00'),
(12613,9,2,200,'19:30','19:35'),
(12613,8,3,320,'21:30','21:35'),
(12613,7,4,450,'23:30',NULL);

INSERT INTO TrainRoute
(TrainNo, StationId, StopOrder, DistanceFromStart, ArrivalTime, DepartureTime)
VALUES
(12614,1,1,0,NULL,'13:00'),
(12614,2,2,170,'15:30','15:35'),
(12614,10,3,350,'18:00',NULL);