CREATE DATABASE WWII;
USE WWII;

-- ������� ��� �������� ���������� � ������� ��������
CREATE TABLE MilitaryUnits (
    MilitaryUnitID INT PRIMARY KEY IDENTITY(1,1),
    UnitName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500)
);

-- ������� ��� �������� ���������� � �������� �����
CREATE TABLE WarEvents (
    WarEventID INT PRIMARY KEY IDENTITY(1,1),
    EventName NVARCHAR(255) NOT NULL,
    EventDate DATE,
    EventLocation NVARCHAR(255),
    Description NVARCHAR(500)
);

-- ������� ��� �������� ���������� � ���������
CREATE TABLE Veterans (
    VeteranID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(255) NOT NULL,
    BirthDate DATE,
    DeathDate DATE,
    MilitaryRank NVARCHAR(100),
    UnitID INT,
    FOREIGN KEY (UnitID) REFERENCES MilitaryUnits(MilitaryUnitID)
);

-- ������� ��� �������� ���������� � ������� � ��������
CREATE TABLE Medals (
    MedalID INT PRIMARY KEY IDENTITY(1,1),
    MedalName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500)
);

-- ������� ��� ����� ��������� � ������
CREATE TABLE VeteranMedals (
    VeteranMedalID INT PRIMARY KEY IDENTITY(1,1),
    VeteranID INT,
    MedalID INT,
    AwardDate DATE,
    FOREIGN KEY (VeteranID) REFERENCES Veterans(VeteranID),
    FOREIGN KEY (MedalID) REFERENCES Medals(MedalID)
);

-- ������� ��� �������� ���������� � ������� �������
CREATE TABLE MilitaryEquipment (
    MilitaryEquipmentID INT PRIMARY KEY IDENTITY(1,1),
    EquipmentName NVARCHAR(255) NOT NULL,
    EquipmentType NVARCHAR(100),
    Description NVARCHAR(500)
);

-- ������� ��� �������� ���������� � ������� ���������
CREATE TABLE MilitaryRoutes (
    MilitaryRouteID INT PRIMARY KEY IDENTITY(1,1),
    RouteName NVARCHAR(255) NOT NULL,
    StartLocation NVARCHAR(255),
    EndLocation NVARCHAR(255),
    Description NVARCHAR(500)
);

-- ������� ��� ����� ����� ��������� � ��������
CREATE TABLE EventEquipment (
    EventEquipmentID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT,
    EquipmentID INT,
    FOREIGN KEY (EventID) REFERENCES WarEvents(WarEventID),
    FOREIGN KEY (EquipmentID) REFERENCES MilitaryEquipment(MilitaryEquipmentID)
);

CREATE TABLE Registration (
    RegistrationID INT PRIMARY KEY IDENTITY(1,1),
    UserLogin NVARCHAR(50) NOT NULL,
    UserPassword NVARCHAR(50) NOT NULL,
	IsAdmin BIT DEFAULT 0
);

INSERT INTO MilitaryUnits (UnitName, Description) VALUES
	('������� ��-27', '�������� ��������'),
	('������� ��', '�������� ��������'),
	('������� ���', '��������-������ ����������������'),
	('������� ���-34/38', '��������-������� ���������'),
	('������� ���-40', '������� ���-40'),
	('����-41', '��������������� ����� ���������'),
	('�-26', '����, ��������� ��������� ��'),
	('��-7', '����, ��������� ��������� ��'),
	('�-34', '����, ��������� ��������� ��'),
	('��-1', '����, ��������� ��������� ��'),
	('��-2', '����, ��������� ��������� ���'),
	('��-2', '�������, ��������� ��������� ���'),
	('��-8', '������� ��������������, ����������� ���'),
	('��-5', '�������, � ��������� ������������ ��� ������������ ���'),
	('������� �������', '������� �������'),
	('�-125', '���������� ��� ������� �-125'),
	('��-47', '������� ��-47'),
	('����� "�����"', '��������������� ����������� ������ "�����"'),
	('���� "������-2"', '���������� �������� �������� �������� "������-2"'),
	('������ B-75', '������ B-75');

-- ������� ������ � ������� MilitaryEquipment (������� �������)
INSERT INTO MilitaryEquipment (EquipmentName, EquipmentType, Description) VALUES
	('������� ��-27', '�������� �������', '�������� ��������'),
	('������� ��', '�������� �������', '�������� ��������'),
	('������� ���', '���������������� �������', '��������-������ ����������������'),
	('������� ���-34/38', '��������-�������', '��������-������� ���������'),
	('������� ���-40', '��������-�������', '������� ���-40'),
	('����-41', '��������������� �����', '��������������� ����� ���������'),
	('�-26', '����', '��������� ��������� ��'),
	('��-7', '����', '��������� ��������� ��'),
	('�-34', '����', '��������� ��������� ��'),
	('��-1', '����', '��������� ��������� ��'),
	('��-2', '����', '��������� ��������� ���'),
	('��-2', '�������', '��������� ��������� ���'),
	('��-8', '��������������', '������� ��������������, ����������� ���'),
	('��-5', '�������', '��� ������������ ������� ��� � ��������� ������������'),
	('������� �������', '�������', '������� �������'),
	('�-125', '�������', '���������� ��� ������� �-125'),
	('��-47', '�������', '������� ��-47'),
	('����� "�����"', '��������������� ������', '��������������� ����������� ������ "�����"'),
	('���� "������-2"', '�������� ������', '���������� �������� �������� �������� "������-2"'),
	('������ B-75', '������', '������ B-75');

-- ������� ������ � ������� WarEvents (������� �����)
INSERT INTO WarEvents (EventName, EventDate, EventLocation, Description) VALUES
	('����� ��� �������', '1941-10-02', '���������� �������', '������������� �������� ����� � ������������� ��������� �� �� ������ �-34 � ������ �������.'),
	('������� ����������', '1941-09-08', '���������', '������������� �������, ������������� ��������� ����� �������, ������� �������� � �����'),
	('������� �����', '1943-07-05', '������� �������', '���������� ������ ��-2 � �-34, � ����� ������� � ����������� ���'),
	('�������� ���������', '1944-06-22', '����������', '�������� ���������� �����, ������ � ������� � �������������� ���������'),
	('������ ��� �������', '1945-08-15', '������� ������', '���������� ����� �������� ����������, ������� ������� ��-47 � ���� "������-2"');

-- ������� ������ � ������� Medals (������ � �������)
INSERT INTO Medals (MedalName, Description) VALUES
	('����� ������������� �����', '������ ������� ��� ������ � ���������� �� ����� ������� ������������� �����'),
	('������ "�� ������"', '������, ��������� �� ������ ��������� � ��������'),
	('����� �������� �������', '������ ������� ��� �� ������ ������ �������'),
	('������ "�� ������ ��� ���������"', '������, ����������� �� ������ � ������� ������������� �����');

INSERT INTO Veterans (FullName, BirthDate, DeathDate, MilitaryRank, UnitID) VALUES
	('������ ���� ��������', '1905-03-12', '1985-11-23', '������� ���������', 1),
	('������ ���� ��������', '1908-06-05', '1970-02-18', '���������', 2),
	('������� ����� ���������', '1910-07-22', '1975-09-11', '�����', 3),
	('�������� ��������� ����������', '1912-09-30', '1965-05-06', '������������', 4),
	('��������� ����� ��������', '1915-01-16', '1982-08-09', '�������', 5);

INSERT INTO VeteranMedals (VeteranID, MedalID, AwardDate) VALUES
	(1, 1, '1942-12-01'),
	(1, 2, '1943-04-15'),
	(2, 3, '1944-07-10'),
	(3, 4, '1945-05-01'),
	(4, 1, '1943-03-19'),
	(5, 2, '1944-11-23');

INSERT INTO MilitaryRoutes (RouteName, StartLocation, EndLocation, Description) VALUES
	('������� 1', '������', '��������', '���� �-34 � ������� ��-27 �������������� �� ���� �������� � ���� ��������'),
	('������� 2', '����', '�������', '������� ������� ����-41 ����������� ������ �������� ������'),
	('������� 3', '�����������', '���������', '���������� ������� � ������� ���'),
	('������� 4', '�����', '�������', '���� ��-2 � ���������� ���������� �������������� ��� ������ ����� ��������'),
	('������� 5', '����������', '������-��-����', '������������� ��������� �����, ���������� ����� � ����������');

INSERT INTO EventEquipment (EventID, EquipmentID) VALUES
	(1, 7),  -- ����� ��� ������� �������������� ����� �-34
	(1, 8),  -- ����� ��� ������� �������������� ����� ��-7
	(2, 12), -- ������� ���������� �������������� ������� ��-2
	(3, 10), -- ������� ����� �������������� ����� ��-1
	(4, 15), -- �������� ��������� �������������� �������� �������
	(5, 18); -- ������ ��� ������� �������������� ���� "������-2"

INSERT INTO Registration (UserLogin, UserPassword, IsAdmin) VALUES
	('admin', 'admin', 1),
	('user', 'user', 0);

SELECT * FROM MilitaryUnits;
SELECT * FROM WarEvents;
SELECT * FROM Veterans;
SELECT * FROM Medals;
SELECT * FROM VeteranMedals;
SELECT * FROM MilitaryEquipment;
SELECT * FROM MilitaryRoutes;
SELECT * FROM EventEquipment;
SELECT * FROM Registration;

-- ����� 1: ������ ��������� � �� ���������
SELECT v.FullName, v.MilitaryRank, m.MedalName, vm.AwardDate
FROM Veterans v
JOIN VeteranMedals vm ON v.VeteranID = vm.VeteranID
JOIN Medals m ON vm.MedalID = m.MedalID;

-- ����� 2: ������ ���� ������� ����� � ��������������� �������
SELECT we.EventName, we.EventDate, me.EquipmentName
FROM WarEvents we
JOIN EventEquipment ee ON we.WarEventID = ee.EventID
JOIN MilitaryEquipment me ON ee.EquipmentID = me.MilitaryEquipmentID;

-- ����� 3: ������ ������� ��������� � �� �������
SELECT RouteName, StartLocation, EndLocation, Description
FROM MilitaryRoutes;

DROP DATABASE WWII;