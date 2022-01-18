
--create database dbSampleTutorialD1

use dbSampleTutorialD1

create table ITEM
(Itemname nvarchar(30) constraint pk_itemName primary key, 
itemtype char(1), 
itemcolor varchar(20)
)

insert into ITEM values('Pocket Knife-Nile','E','Brown')
insert into ITEM values('Pocket Knife-Avon','E','Brown')
insert into ITEM values('Compass','N', null)
insert into ITEM values('Geo positioning system','N', null)
insert into ITEM values('Elephant Polo stick','R','Bamboo')
insert into ITEM values('Camel Saddle','R','Brown')
insert into ITEM values('Sextant','N', null)
insert into ITEM values('Map Measure','N', null)
insert into ITEM values('Boots-snake proof','C','Green')
insert into ITEM values('Pith Helmet','C','Khaki')
insert into ITEM values('Hat-polar Explorer','C','White')
insert into ITEM values('Exploring in 10 Easy Lessons','B', null)
insert into ITEM values('Hammock','F','Khaki')
insert into ITEM values('How to win Foreign Friends','B', null)
insert into ITEM values('Map case','E','Brown')
insert into ITEM values('Safari Chair','F','Khaki')
insert into ITEM values('Safari cooking kit','F','Khaki')
insert into ITEM values('Stetson','C','Black')
insert into ITEM values('Tent - 2 person','F','Khaki')
insert into ITEM values('Tent - 8 person','F','Khaki')

create table EMP
(EmpNo int identity(1,1)primary key,
Empname varchar(20), 
Empsalary int, 
--Department varchar(20) constraint fk_deptName foreign key references DEPARTMENT(Deptname) null,
Department varchar(20) null,
Bossno int references EMP(EmpNo) null
)

insert into EMP values('Alice','75000','Management', null)
insert into EMP values('Ned','45000','Marketing', 1)
insert into EMP values('Andrew','25000','Marketing', 2)
insert into EMP values('Clare','22000','Marketing', 2)
insert into EMP values('Todd','38000','Accounting', 1)
insert into EMP values('Nancy','22000','Accounting', 5)
insert into EMP values('Brier','43000','Purchasing', 1)
insert into EMP values('Sarah','56000','Purchasing', 7)
insert into EMP values('Sophile','35000','Personnel', 1)
insert into EMP values('Sanjay','15000','Navigation', 3)
insert into EMP values('Rita','15000','Books', 4)
insert into EMP values('Gigi','16000','Clothes', 4)
insert into EMP values('Maggie','11000','Clothes', 4)
insert into EMP values('Paul','15000','Equipment', 3)
insert into EMP values('James','15000','Equipment', 3)
insert into EMP values('Pat','15000','Furniture', 3)
insert into EMP values('Mark','15000','Recreation', 3)

create table DEPARTMENT
(Deptname varchar(20) constraint pk_deptName primary key, 
Deptfloor int, 
Deptphone int, 
MgrId int constraint fk_empNo foreign key references EMP(EmpNo) not null
)

insert into DEPARTMENT values('Management',5,34, 1)
insert into DEPARTMENT values('Books',1,81, 4)
insert into DEPARTMENT values('Clothes',2,24, 4)
insert into DEPARTMENT values('Equipment',3,57, 3)
insert into DEPARTMENT values('Furniture',4,14, 3)
insert into DEPARTMENT values('Navigation',1,41, 3)
insert into DEPARTMENT values('Recreation',2,29, 4)
insert into DEPARTMENT values('Accounting',5,35, 5)
insert into DEPARTMENT values('Purchasing',5,36, 7)
insert into DEPARTMENT values('Personnel',5,37, 9)
insert into DEPARTMENT values('Marketing',5,38, 2)

alter table EMP add foreign key (Department) references DEPARTMENT(Deptname)

create table SALES
(Salesno int identity(101,1) constraint pk_salesNo primary key, 
Saleqty int, 
itemname nvarchar(30) constraint fk_itemName foreign key references ITEM(Itemname) null,
Deptname varchar(20) constraint fk_deptName foreign key references DEPARTMENT(Deptname) null
)

insert into SALES values(2,'Boots-snake proof', 'Clothes')
insert into SALES values(1,'Pith Helmet', 'Clothes')
insert into SALES values(1,'Sextant', 'Navigation')
insert into SALES values(3,'Hat-polar Explorer', 'Clothes')
insert into SALES values(5,'Pith Helmet', 'Equipment')
insert into SALES values(2,'Pocket Knife-Nile', 'Clothes')
insert into SALES values(3,'Pocket Knife-Nile', 'Recreation')
insert into SALES values(1,'Compass', 'Navigation')
insert into SALES values(2,'Geo positioning system', 'Navigation')
insert into SALES values(5,'Map Measure', 'Navigation')
insert into SALES values(1,'Geo positioning system', 'Books')
insert into SALES values(1,'Sextant', 'Books')
insert into SALES values(3,'Pocket Knife-Nile', 'Books')
insert into SALES values(1,'Pocket Knife-Nile', 'Navigation')
insert into SALES values(1,'Pocket Knife-Nile', 'Equipment')
insert into SALES values(1,'Sextant', 'Clothes')
insert into SALES values(1, null, 'Equipment')
insert into SALES values(1, null, 'Recreation')
insert into SALES values(1, null, 'Furniture')
insert into SALES values(1,'Pocket Knife-Nile', 'Furniture')
insert into SALES values(1,'Exploring in 10 easy lessons', 'Books')
insert into SALES values(1,'How to win foreign friends', null)
insert into SALES values(1,'Compass', null)
insert into SALES values(1,'Pith Helmet', null)
insert into SALES values(1,'Elephant Polo stick', 'Recreation')
insert into SALES values(1,'Camel Saddle', 'Recreation')


