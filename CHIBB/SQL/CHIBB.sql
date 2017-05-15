DROP TABLE IF EXISTS Sensors, SensorValues, Accounts;

CREATE TABLE Sensors (
    Identifier varchar(255) NOT NULL PRIMARY KEY,
    SensorName varchar(255),
    SensorType varchar(255),
    SensorComment varchar(255),
    Active bool
);

CREATE TABLE SensorValues (
    ValueKey int NOT NULL PRIMARY KEY,
    Identifier varchar(255) references Sensors(Identifier),
    SensorData int,
    DataDate varchar(255),
    IpAdress varchar(255)
);

CREATE TABLE Accounts (
    Username varchar(255) NOT NULL PRIMARY KEY,
    Password varchar(255) NOT NULL,
    Email varchar(255) NOT NULL,
    Role varchar(255) NOT NULL,
    Active bool NOT NULL
)
