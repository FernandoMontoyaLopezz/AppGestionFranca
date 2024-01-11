CREATE DATABASE DbGestionFranca;

USE DbGestionFranca;

CREATE TABLE Subsidiary
(
    SubsidiaryId INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(MAX) NOT NULL,
    Name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Technician
(
    TechnicianId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Code NVARCHAR(MAX) NOT NULL,
    Salary DECIMAL NOT NULL,
    SubsidiaryId INT,
    FOREIGN KEY (SubsidiaryId) REFERENCES Subsidiary(SubsidiaryId)
);


CREATE TABLE Item
(
    ItemId INT PRIMARY KEY,
    Code NVARCHAR(MAX) NOT NULL,
    Name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE TechnicianItem
(
    TechnicianItemId INT IDENTITY(1,1) PRIMARY KEY,
    TechnicianId INT,
    ItemId INT,
    Quantity INT,
    FOREIGN KEY (TechnicianId) REFERENCES Technician(TechnicianId),
    FOREIGN KEY (ItemId) REFERENCES Item(ItemId)
);

INSERT INTO Subsidiary VALUES (1, '1A', 'North office');
INSERT INTO Subsidiary VALUES (2, '2B', 'South office');
INSERT INTO Subsidiary VALUES (3, '3C', 'East office');
INSERT INTO Subsidiary VALUES (4, '4D', 'West office');
INSERT INTO Subsidiary VALUES (5, '5E', 'Central office');
INSERT INTO Subsidiary VALUES (6, '6F', 'Headquarters');

INSERT INTO Item VALUES (1, '001', 'First Item');
INSERT INTO Item VALUES (2, '002', 'Second Item');
INSERT INTO Item VALUES (3, '003', 'Third Item');
INSERT INTO Item VALUES (4, '004', 'Fourth Item');
INSERT INTO Item VALUES (5, '005', 'Fifth Item');
INSERT INTO Item VALUES (6, '006', 'Special Item');