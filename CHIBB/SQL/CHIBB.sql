DROP TABLE IF EXISTS Sensors, SensorValues;

CREATE TABLE Sensors (
    Identifier varchar(255) NOT NULL PRIMARY KEY,
    SensorName varchar(255),
    SensorType varchar(255),
    SensorComment varchar(255) 
);

CREATE TABLE SensorValues (
    ValueKey int NOT NULL PRIMARY KEY,
    Identifier varchar(255) references Sensors(Identifier),
    SensorData int,
    DataDate varchar(255),
    IpAdress varchar(255)
);
