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

-- ���������� ������� MilitaryUnits (������� �������������)
INSERT INTO MilitaryUnits (UnitName, Description)
VALUES
('1-� ����������� �������� �����', '������� �������� ����������, ������������� � �������� ���������'),
('316-� ���������� ������� (������������)', '������������ � ����� �� ������, ������� ������������'),
('62-� �����', '��������� ����������� ��� ������������� �������'),
('1-� �������������� ����������� ������', '����������� ����������, �������������� ��������� ���������'),
('����������� ��������� �����', '������������� ���������� ���������� ("������")'),
('��������� ��������������� ��������', '������������������ ������������� ��� ������ � �������');

-- ���������� ������� WarEvents (������� �������)
INSERT INTO WarEvents (EventName, EventDate, EventLocation, Description)
VALUES
('������� ��������� ��������', '1941-06-22', '�����', '����������� ������� � �������������� ��� � ��'),
('����� �� ������', '1941-10-02', '������', '������������� �-34 � ��� � ����������������'),
('�������������� �����', '1942-08-23', '����������', '�������� ���������� ��-2 � ��-43'),
('������� �����', '1943-07-05', '�����', '���������� �������� �������� � �������� �-34 � ��2'),
('�������� "���������"', '1944-06-23', '����������', '������� ������������� "�����" � ������� ��-7'),
('����� �������', '1945-04-16', '������', '���������� ���� ����� ����������, ������� ���-44');

-- ���������� ������� Veterans (��������)
INSERT INTO Veterans (FullName, BirthDate, DeathDate, MilitaryRank, UnitID)
VALUES
('���� ��������', '1893-01-01', '1941-11-18', '�������-�����', 2),
('������� ������', '1900-02-12', '1982-03-18', '������ ���������� �����', 3),
('��������� ���������', '1913-03-06', '1985-11-13', '������ �������', 4),
('��� ���������������', '1923-09-13', '1941-11-29', '������������', 2),
('������� ����������', '1914-10-14', '1941-12-18', '������� ���������', 1),
('����� ������', '1921-08-18', '1943-08-01', '������� ���������', 4);

-- ���������� ������� Medals (������ � �������)
INSERT INTO Medals (MedalName, Description)
VALUES
('����� ���������� �����', '������ ������� ������� �� �������'),
('����� ������', '���� �� ������ ������� ����'),
('����� �������� �������', '�� ������ ��������� � ��������'),
('����� ������������� �����', '�� ����� � ������ � ���'),
('������ "�� ������"', '�� ������ �������� � ���'),
('����� �����', '�� ���������� ������� �������� � ������������ �������');

-- ���������� ������� VeteranMedals (������� ���������)
INSERT INTO VeteranMedals (VeteranID, MedalID, AwardDate)
VALUES
(1, 1, '1942-04-12'), -- �������� - ����� ���������� �����
(2, 1, '1944-03-19'), -- ������ - ����� ���������� �����
(3, 1, '1943-05-24'), -- ��������� - ����� ���������� ����� (������)
(3, 1, '1943-08-24'),
(3, 1, '1944-08-19'),
(4, 1, '1942-02-16'), -- ��������������� - ����� ���������� �����
(5, 1, '1990-05-05'), -- ���������� - ����� ���������� ����� (���������)
(6, 1, '1990-05-05'); -- ������ - ����� ���������� ����� (���������)

-- ���������� ������� MilitaryEquipment (������� �������)
-- ������� ������ � ������� �������
INSERT INTO MilitaryEquipment (EquipmentName, EquipmentType, Description)
VALUES 
('����������� �����-������ �������', '������', '������ ������ �������� ������������, ���������������� � ���� � ������ �����'),
('������� Ը�����', '������', '���� �� ������ � ���� �������� ���������, ������������� �.�. Ը�������'),
('7,62-�� ������ ������ (��)', '������', '������ ������ �������� ��������, �������� ������ ������ ���� � ���� �����'),
('�������� ������ (��)', '������', '�������� ������ ������� �� ��� ��������� �� ������������'),
('12,7-�� ���������������� ������ (��)', '������', '���������������� ������ �������� ������� 12,7 ��'),
('7,62-�� ��������-������ �������� (���)', '������', '��������� ��������-������, �������������� ���'),
('12,7-�� ���������������� ������ ������� ����������� � ����������� (����)', '������', '����������� ������, ������� �������������� ��� ��������� �������������'),
('7,62-�� ��������-������ ������� (���)', '������', '����� �������� ��������-������ ������� ����� � ���� �����'),
('����', '������', '��������������� ����� ��������, 14,5-�� ������ ��� ������ � �������������'),
('7,62-�� ��������� ������ �. �. �������� (��-43)', '������', '��������� ������, ��������� �� ����� ������� �������'),
('���������������� ������ ������� �. �. ����������� (���-44) � ������ ������ �������� (���)', '������', '������ 14,5-�� ������ � ����� ������ ������ ��� ������������� ������'),
('�������� �-125', '���������', '��������� �������� ������������� ������������ (����� � 1946 ����)'),
('�-26', '����', '��������� ����� ���� 1930-� �����, ������������� � ��������� ������� �����'),
('��2', '����', '������ ���� "����� ������" � ������ 122-�� �������'),
('�34', '����', '������� ���� �-34, �������� ���� ���� � ���� �����'),
('������', '����������', '���������� ������� ��������� ���� ��-13'),
('��-7', '������', '���� �� ������ ��������� ������������ ����� �����'),
('��-2', '������', '��������� "�������� ����", ����� �������� ������ ������ � �������');

-- ���������� ������� MilitaryRoutes (������� ��������)
INSERT INTO MilitaryRoutes (RouteName, StartLocation, EndLocation, Description)
VALUES
('������ �����', '���������', '������', '������� ������ ����� ��������� ����� � ���������� ��� � ��'),
('���������� �����', '�������', '������', '�������� ���� ����������� � ������� ��2 � �-34'),
('��������� ����', '������', '����������', '������� �������� ����������� ��-7 � ��-2'),
('�������� ����', '���', '��������', '������� ������������ "�����" ����� ������� ������');

-- ���������� ������� EventEquipment (����� ������� � �������)
INSERT INTO EventEquipment (EventID, EquipmentID)
VALUES
(1, 6),  -- ������� ������ - ���
(1, 3),  -- ������� ������ - ��
(2, 15), -- ����� �� ������ - �-34
(2, 8),  -- ����� �� ������ - ���
(3, 17), -- ���������� - ��-2
(3, 10), -- ���������� - ��-43
(4, 14), -- ����� - ��2
(4, 15), -- ����� - �-34
(5, 16), -- ��������� - ������
(5, 16), -- ��������� - ��-7
(6, 11), -- ������ - ���-44
(6, 15); -- ������ - �-34

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