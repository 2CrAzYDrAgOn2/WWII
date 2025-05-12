CREATE DATABASE WWII;
USE WWII;

-- Таблица для хранения информации о военных единицах
CREATE TABLE MilitaryUnits (
    MilitaryUnitID INT PRIMARY KEY IDENTITY(1,1),
    UnitName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500)
);

-- Таблица для хранения информации о событиях войны
CREATE TABLE WarEvents (
    WarEventID INT PRIMARY KEY IDENTITY(1,1),
    EventName NVARCHAR(255) NOT NULL,
    EventDate DATE,
    EventLocation NVARCHAR(255),
    Description NVARCHAR(500)
);

-- Таблица для хранения информации о ветеранах
CREATE TABLE Veterans (
    VeteranID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(255) NOT NULL,
    BirthDate DATE,
    DeathDate DATE,
    MilitaryRank NVARCHAR(100),
    UnitID INT,
    FOREIGN KEY (UnitID) REFERENCES MilitaryUnits(MilitaryUnitID)
);

-- Таблица для хранения информации о медалях и наградах
CREATE TABLE Medals (
    MedalID INT PRIMARY KEY IDENTITY(1,1),
    MedalName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500)
);

-- Таблица для связи ветеранов и наград
CREATE TABLE VeteranMedals (
    VeteranMedalID INT PRIMARY KEY IDENTITY(1,1),
    VeteranID INT,
    MedalID INT,
    AwardDate DATE,
    FOREIGN KEY (VeteranID) REFERENCES Veterans(VeteranID),
    FOREIGN KEY (MedalID) REFERENCES Medals(MedalID)
);

-- Таблица для хранения информации о военной технике
CREATE TABLE MilitaryEquipment (
    MilitaryEquipmentID INT PRIMARY KEY IDENTITY(1,1),
    EquipmentName NVARCHAR(255) NOT NULL,
    EquipmentType NVARCHAR(100),
    Description NVARCHAR(500)
);

-- Таблица для хранения информации о военных маршрутах
CREATE TABLE MilitaryRoutes (
    MilitaryRouteID INT PRIMARY KEY IDENTITY(1,1),
    RouteName NVARCHAR(255) NOT NULL,
    StartLocation NVARCHAR(255),
    EndLocation NVARCHAR(255),
    Description NVARCHAR(500)
);

-- Таблица для связи между событиями и техникой
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

-- Заполнение таблицы MilitaryUnits (Военные подразделения)
INSERT INTO MilitaryUnits (UnitName, Description)
VALUES
('1-я гвардейская танковая армия', 'Элитное танковое соединение, участвовавшее в ключевых операциях'),
('316-я стрелковая дивизия (Панфиловская)', 'Прославилась в битве за Москву, оборона Волоколамска'),
('62-я армия', 'Защитники Сталинграда под командованием Чуйкова'),
('1-й истребительный авиационный корпус', 'Авиационное соединение, обеспечивавшее воздушное прикрытие'),
('Гвардейские миномётные части', 'Подразделения реактивной артиллерии ("Катюши")'),
('Отдельный противотанковый дивизион', 'Специализированные подразделения для борьбы с танками');

-- Заполнение таблицы WarEvents (Военные события)
INSERT INTO WarEvents (EventName, EventDate, EventLocation, Description)
VALUES
('Оборона Брестской крепости', '1941-06-22', 'Брест', 'Героическая оборона с использованием ППД и ДП'),
('Битва за Москву', '1941-10-02', 'Москва', 'Использование Т-34 и ППШ в контрнаступлении'),
('Сталинградская битва', '1942-08-23', 'Сталинград', 'Массовое применение Ил-2 и СГ-43'),
('Курская битва', '1943-07-05', 'Курск', 'Крупнейшее танковое сражение с участием Т-34 и ИС2'),
('Операция "Багратион"', '1944-06-23', 'Белоруссия', 'Широкое использование "Катюш" и авиации Ла-7'),
('Штурм Берлина', '1945-04-16', 'Берлин', 'Применение всех видов вооружения, включая КПВ-44');

-- Заполнение таблицы Veterans (Ветераны)
INSERT INTO Veterans (FullName, BirthDate, DeathDate, MilitaryRank, UnitID)
VALUES
('Иван Панфилов', '1893-01-01', '1941-11-18', 'Генерал-майор', 2),
('Василий Чуйков', '1900-02-12', '1982-03-18', 'Маршал Советского Союза', 3),
('Александр Покрышкин', '1913-03-06', '1985-11-13', 'Маршал авиации', 4),
('Зоя Космодемьянская', '1923-09-13', '1941-11-29', 'Красноармеец', 2),
('Дмитрий Лавриненко', '1914-10-14', '1941-12-18', 'Старший лейтенант', 1),
('Лидия Литвяк', '1921-08-18', '1943-08-01', 'Младший лейтенант', 4);

-- Заполнение таблицы Medals (Медали и награды)
INSERT INTO Medals (MedalName, Description)
VALUES
('Герой Советского Союза', 'Высшая степень отличия за героизм'),
('Орден Ленина', 'Один из высших орденов СССР'),
('Орден Красного Знамени', 'За особую храбрость и мужество'),
('Орден Отечественной войны', 'За вклад в победу в ВОВ'),
('Медаль "За отвагу"', 'За личное мужество в бою'),
('Орден Славы', 'За выдающиеся заслуги рядового и сержантского состава');

-- Заполнение таблицы VeteranMedals (Награды ветеранов)
INSERT INTO VeteranMedals (VeteranID, MedalID, AwardDate)
VALUES
(1, 1, '1942-04-12'), -- Панфилов - Герой Советского Союза
(2, 1, '1944-03-19'), -- Чуйков - Герой Советского Союза
(3, 1, '1943-05-24'), -- Покрышкин - Герой Советского Союза (трижды)
(3, 1, '1943-08-24'),
(3, 1, '1944-08-19'),
(4, 1, '1942-02-16'), -- Космодемьянская - Герой Советского Союза
(5, 1, '1990-05-05'), -- Лавриненко - Герой Советского Союза (посмертно)
(6, 1, '1990-05-05'); -- Литвяк - Герой Советского Союза (посмертно)

-- Заполнение таблицы MilitaryEquipment (Военная техника)
-- Вставка данных о военной технике
INSERT INTO MilitaryEquipment (EquipmentName, EquipmentType, Description)
VALUES 
('Трёхлинейное ружье-пулемёт „Мадсен“', 'Оружие', 'Ручной пулемёт датского производства, использовавшийся в РККА в начале войны'),
('Автомат Фёдоров', 'Оружие', 'Один из первых в мире серийных автоматов, разработанный В.Г. Фёдоровым'),
('7,62-мм ручной пулемёт (ДП)', 'Оружие', 'Ручной пулемёт Дегтярёва пехотный, основной ручной пулемёт РККА в годы войны'),
('Танковый пулемёт (ДТ)', 'Оружие', 'Танковая версия пулемёта ДП для установки на бронетехнику'),
('12,7-мм крупнокалиберный пулемёт (ДК)', 'Оружие', 'Крупнокалиберный пулемёт Дегтярёва калибра 12,7 мм'),
('7,62-мм пистолет-пулемёт Дегтярёва (ППД)', 'Оружие', 'Советский пистолет-пулемёт, предшественник ППШ'),
('12,7-мм крупнокалиберный пулемёт системы Шпитального и Владимирова (ШВАК)', 'Оружие', 'Авиационный пулемёт, позднее адаптированный для наземного использования'),
('7,62-мм пистолет-пулемёт Шпагина (ППШ)', 'Оружие', 'Самый массовый пистолет-пулемёт Красной Армии в годы войны'),
('ПТРД', 'Оружие', 'Противотанковое ружьё Дегтярёва, 14,5-мм оружие для борьбы с бронетехникой'),
('7,62-мм станковый пулемёт П. М. Горюнова (СГ-43)', 'Оружие', 'Станковый пулемёт, пришедший на смену пулемёту Максима'),
('Крупнокалиберный пулемёт системы С. В. Владимирова (КПВ-44) и ручной пулемёт Дегтярёва (РПД)', 'Оружие', 'Мощный 14,5-мм пулемёт и новый ручной пулемёт под промежуточный патрон'),
('Мотоцикл К-125', 'Транспорт', 'Советский мотоцикл послевоенного производства (введён в 1946 году)'),
('Т-26', 'Танк', 'Советский лёгкий танк 1930-х годов, участвовавший в начальном периоде войны'),
('ИС2', 'Танк', 'Тяжёлый танк "Иосиф Сталин" с мощным 122-мм орудием'),
('Т34', 'Танк', 'Средний танк Т-34, основной танк РККА в годы войны'),
('Катюша', 'Артиллерия', 'Реактивная система залпового огня БМ-13'),
('Ла-7', 'Самолёт', 'Один из лучших советских истребителей конца войны'),
('Ил-2', 'Самолёт', 'Штурмовик "Летающий танк", самый массовый боевой самолёт в истории');

-- Заполнение таблицы MilitaryRoutes (Военные маршруты)
INSERT INTO MilitaryRoutes (RouteName, StartLocation, EndLocation, Description)
VALUES
('Дорога жизни', 'Ленинград', 'Кобона', 'Ледовая трасса через Ладожское озеро с прикрытием ППШ и ДП'),
('Берлинское шоссе', 'Кюстрин', 'Берлин', 'Основной путь наступления с танками ИС2 и Т-34'),
('Воздушный мост', 'Москва', 'Сталинград', 'Маршрут поставок авиатехники Ла-7 и Ил-2'),
('Огненная дуга', 'Орёл', 'Белгород', 'Маршрут передвижения "Катюш" перед Курской битвой');

-- Заполнение таблицы EventEquipment (Связь событий и техники)
INSERT INTO EventEquipment (EventID, EquipmentID)
VALUES
(1, 6),  -- Оборона Бреста - ППД
(1, 3),  -- Оборона Бреста - ДП
(2, 15), -- Битва за Москву - Т-34
(2, 8),  -- Битва за Москву - ППШ
(3, 17), -- Сталинград - Ил-2
(3, 10), -- Сталинград - СГ-43
(4, 14), -- Курск - ИС2
(4, 15), -- Курск - Т-34
(5, 16), -- Багратион - Катюша
(5, 16), -- Багратион - Ла-7
(6, 11), -- Берлин - КПВ-44
(6, 15); -- Берлин - Т-34

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

-- Отчет 1: Список ветеранов с их наградами
SELECT v.FullName, v.MilitaryRank, m.MedalName, vm.AwardDate
FROM Veterans v
JOIN VeteranMedals vm ON v.VeteranID = vm.VeteranID
JOIN Medals m ON vm.MedalID = m.MedalID;

-- Отчет 2: Список всех событий войны и задействованной техники
SELECT we.EventName, we.EventDate, me.EquipmentName
FROM WarEvents we
JOIN EventEquipment ee ON we.WarEventID = ee.EventID
JOIN MilitaryEquipment me ON ee.EquipmentID = me.MilitaryEquipmentID;

-- Отчет 3: Список военных маршрутов и их локаций
SELECT RouteName, StartLocation, EndLocation, Description
FROM MilitaryRoutes;

DROP DATABASE WWII;