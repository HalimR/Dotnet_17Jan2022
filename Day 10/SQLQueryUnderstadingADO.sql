CREATE DATABASE dbCMSConsole

--CREATE DATABASE dbSample28Jan2022

use dbSample28Jan2022

CREATE TABLE tblUser
(userid VARCHAR(20) PRIMARY KEY,
password VARCHAR(20),
name VARCHAR(20),
age INT
)

INSERT INTO tblUser VALUES('tim','123','Tim T', 22)

SELECT * FROM tblUser

CREATE PROC proc_GetAllUsers
AS
BEGIN

	SELECT * FROM tblUser
END

EXEC  proc_GetAllUSers