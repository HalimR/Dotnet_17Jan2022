CREATE DATABASE dbEmployeeSample

CREATE TABLE tblEmployee
( Id INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(20),
Age INT
)

CREATE PROC proc_InsertEmployee 
(@emp_name VARCHAR(20),
@emp_age INT)
AS
BEGIN
	INSERT INTO tblEmployee(name,age) VALUES (@emp_name,@emp_age)
END

CREATE PROC proc_UpdateEmployeeDetail
(@emp_id INT, 
@emp_name VARCHAR(20),
@emp_age INT)
AS
BEGIN
	UPDATE tblEmployee SET Name = @emp_name, Age = @emp_age WHERE Id = @emp_id
END

CREATE PROC proc_DeleteEmployeeById(@emp_id INT)
AS
BEGIN
	DELETE FROM tblEmployee WHERE Id = @emp_id
END

CREATE PROC proc_GetEmployeeById(@emp_id INT)
AS
BEGIN
	SELECT * FROM tblEmployee WHERE Id = @emp_id
END

CREATE PROC proc_GetAllEmployee
AS
BEGIN
	SELECT * FROM tblEmployee
END

--testing sp--

proc_InsertEmployee 'Halim', 26

proc_GetAllEmployee

proc_GetEmployeeById 1

proc_UpdateEmployeeDetail 1, 'HalimR', 27

proc_DeleteEmployeeById 1



