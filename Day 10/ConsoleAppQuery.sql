use dbCMSConsole

CREATE TABLE tblUser
(User_Id INT IDENTITY(101,1) PRIMARY KEY,
User_Name VARCHAR(20),
User_Password VARCHAR(20),
User_Type INT,
User_Experience INT,
User_Specialization VARCHAR(20)
)

CREATE TABLE tblAppointment
(App_Id INT IDENTITY(1,1) PRIMARY KEY,
Pat_Id VARCHAR(20),
Doc_Id VARCHAR(20),
App_Date DATETIME,
App_Outstanding FLOAT,
App_PayStatus VARCHAR(20),
App_PatRemarks VARCHAR(20),
App_DocRemarks VARCHAR(20)
)

--TABLE tblUser
INSERT INTO tblUser VALUES('Bob','abcd1234', 1, null, null)
INSERT INTO tblUser VALUES('Sarah','abcd1234', 2, 5, 'Family Physician')
INSERT INTO tblUser VALUES('Ash','abcd1234', 1, null, null)
INSERT INTO tblUser VALUES('Liam','abcd1234', 2, 4, 'Cardiologist')

--TABLE tblAppointment
INSERT INTO tblAppointment VALUES(101,102,'2022-01-25 10:00:00',0,1,null,null)
INSERT INTO tblAppointment VALUES(101,102,'2022-01-26 10:00:00',124.61,2,null,null)
INSERT INTO tblAppointment VALUES(103,104,'2022-01-28 14:00:00',21.21,2,null,null)
INSERT INTO tblAppointment VALUES(103,104,'2022-01-25 14:00:00',0,3,null,null)