create database MiniDemka

use MiniDemka

create table City(
ID int primary key,
Name varchar(max)
);


create table Country(
ID int primary key,
Name varchar(max),
EnglishName varchar(max),
Code varchar(max),
Code2 varchar(max),
);

create table Gender(
Code char(1) primary key,
Description varchar(max)
);

create table Events(
ID int primary key identity,
Event varchar(max),
Date datetime,
Days int,
CityID int,
foreign key(CityId) references City(ID),
Photo varchar(max)
);

create table Moderators(
ID int primary key identity,
LastName varchar(max),
FirstName varchar(max),
Patronymic varchar(max),
Gender char(1),
foreign key(Gender) references Gender(Code),
Email varchar(max),
Birthday datetime,
Country int,
foreign key(Country) references Country(ID),
Phone varchar(max),
Direction varchar(max),
EventID int,
foreign key(EventID) references Events(ID),
Password varchar(max),
Photo varchar(max),
);

create table Jury(
ID int primary key identity,
LastName varchar(max),
FirstName varchar(max),
Patronymic varchar(max),
Gender char(1),
foreign key(Gender) references Gender(Code),
Email varchar(max),
Birthday datetime,
Country int,
foreign key(Country) references Country(ID),
Phone varchar(max),
Direction varchar(max),
EventID int,
foreign key(EventID) references Events(ID),
Password varchar(max),
Photo varchar(max),
);


create table Organizers(
ID int primary key identity,
LastName varchar(max),
FirstName varchar(max),
Patronymic varchar(max),
Gender char(1),
foreign key(Gender) references Gender(Code),
Email varchar(max),
Birthday datetime,
Country int,
foreign key(Country) references Country(ID),
Phone varchar(max),
Password varchar(max),
Photo varchar(max),
);

create table Exhibitors(
ID int primary key identity,
LastName varchar(max),
FirstName varchar(max),
Patronymic varchar(max),
Gender char(1),
foreign key(Gender) references Gender(Code),
Email varchar(max),
Birthday datetime,
Country int,
foreign key(Country) references Country(ID),
Phone varchar(max),
Password varchar(max),
Photo varchar(max),
);


create table Activities(
ID int primary key identity,
Activity varchar(max),
DateStart datetime,
TimeStart time,
Days int,
EventID int,
foreign key(EventID) references Events(ID),
ModeratorID int,
foreign key(ModeratorID) references Moderators(ID),
JuryID int,
foreign key(JuryID) references Jury(ID)
);

insert into Gender
values('м','мужской'),('ж','женский')