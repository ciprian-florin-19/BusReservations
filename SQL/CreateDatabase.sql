create database BusReservations;

create table Users(
Id uniqueidentifier not null default newid(),
Name nvarchar(max),
PhoneNumber nvarchar(max),
Email nvarchar(max),
Status nvarchar(max),
primary key(Id) 
);

create table Accounts(
Id uniqueidentifier not null default newid(),
UserId uniqueidentifier not null,
HasAdminPrivileges bit,
Password nvarchar(max),
Username nvarchar(max),
primary key(Id),
foreign key(UserId)
references Users(Id)
);

create table Buses(
Id uniqueidentifier not null default newid(),
Name nvarchar(max),
Capacity int not null,
primary key(Id)
);

create table TimeTables(
Id uniqueidentifier not null default newid(),
DepartureDate datetime2(7) not null,
ArrivalDate datetime2(7) not null,
Duration time(7) not null,
primary key(Id)
);

create table DrivenRoutes(
Id uniqueidentifier not null default newid(),
Start nvarchar(max) not null,
Destination nvarchar(max) not null,
SeatPrice real not null,
TimeTableId uniqueidentifier not null,
primary key(Id),
foreign key(TimeTableId) references Timetables(Id)
);

create table BusDrivenRoutes(
Id uniqueidentifier not null default newid(),
BusId uniqueidentifier not null,
DrivenRouteId uniqueidentifier not null,
primary key(Id),
foreign key(BusId) references Buses(Id),
foreign key(DrivenRouteId) references DrivenRoutes(Id)
);

create table Seats(
Id uniqueidentifier not null default newid(),
Type int not null,
Discount real not null,
SeatNumber int not null,
BusDrivenRouteId uniqueidentifier not null,
primary key(Id),
foreign key(BusDrivenRouteId) references BusDrivenRoutes(Id)
);

create table Reservations(
Id uniqueidentifier not null default newid(),
UserId uniqueidentifier not null,
SeatId uniqueidentifier not null,
FinalSeatPrice real not null,
BusDrivenRouteId uniqueidentifier not null,
primary key(Id),
foreign key(UserId) references Users(Id),
foreign key(SeatId) references Seats(Id),
foreign key(BusDrivenRouteId) references BusDrivenRoutes(Id)
);