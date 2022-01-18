
----select a database
--use master

----create a database
--create database dbSample17Jan2022

----select the database
--use dbSample17Jan2022

----create table
--CREATE TABLE tblLocation
--(locationName VARCHAR(20) PRIMARY KEY,
--zipcode VARCHAR(5)
--)

----to view table
--sp_help tblLocation

----to add a column
--ALTER TABLE tblLocation
--ADD anotherColumn INT

----to drop a column
--ALTER TABLE tblLocation
--DROP COLUMN anotherColumn

----to dtop/delete table
--DROP TABLE tblLocation

---- identity(101,1)
---- the 101 is the seed (initial value)
---- the 1 is the increment value(increase by 1)

----Tutorial
--CREATE TABLE tblEmployee
--(EmployeeID INT identity(101,1) primary key,
--Name varchar(20) not null,
--Phone varchar(15),
----Location varchar(20) foreign key fk_EmpLocation references tblLocation(locationName),
--Location varchar(20) references tblLocation(locationName),
--Age int,
--Email varchar(100),
--JoiningDate DateTime,
--Role varchar(15) check (role in ('Manager','Developer','Sr.Developer'))
--)

--sp_help tblSkill

--create table tblSkill
--(skillName varchar(20) constraint pk_skill primary key,
--skillDesc varchar(20)
--)

--create table tblEmployeeSkill
----(EmpID int constraint fk_empSkill foreign key references tblEmployee(EmployeeID),
--(EmpID int  references tblEmployee(EmployeeID),
--Skill varchar(20) references tblSkill(skillName),
--Skill_level float,
--primary key(EmpID, Skill)
--)

--sp_help tblEmployeeSkill

--insert into tblLocation values('xyz','123')
--insert into tblLocation 
--(zipcode, locationName)
--values
--('333','zzz')

--insert into tblEmployee
--(Name, Location, Age, Role, Phone, Email)
--values
--('ABC', 'xyz', 31, 'Manager', '123456789', 'abc@gmail.com')

--insert into tblEmployee
--(Name, Location, Age, Role, Phone, Email)
--values
--('ABC', 'zzz', 31, 'Developer', '987654321', 'cba@gmail.com')

--select * from tblEmployee

--insert into tblSkill values('C','PLT')
--insert into tblSkill values('C++','OOPS')
--insert into tblSkill values('Java','Web')
--insert into tblSkill values('.NET','Web')
--insert into tblSkill values('SQL','RDBMS')

--insert into tblEmployeeSkill values (101, 'C', 9)
--insert into tblEmployeeSkill values (101, 'C++', 8)
--insert into tblEmployeeSkill values (101, 'Java', 7)

--update tblEmployeeSkill set Skill_Level = 8 where EmpID = 101 and Skill = 'Java'

--delete from tblEmployeeSkill where EmpID = 101 and Skill = 'Java'