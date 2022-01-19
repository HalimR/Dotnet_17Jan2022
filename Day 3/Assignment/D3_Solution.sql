USE pubs

--1) Select the author firstname and last name
SELECT au_fname 'First Name', au_lname 'Last Name' FROM authors
ORDER BY 1

SELECT CONCAT(au_fname,' ', au_lname) 'Author Full Name' FROM authors
ORDER BY 1

--2) Sort the titles by the title name in descending order and print all the details
SELECT * FROM titles
ORDER BY title DESC

--3) Print the number of titles published by every author
SELECT TA.au_id 'Author ID', COUNT(T.title) 'No. of Titles' 
FROM titles T JOIN titleauthor TA 
ON T.title_id = TA.title_id
GROUP BY TA.au_id

--4) print the author name and title name
SELECT CONCAT(A.au_fname,' ', A.au_lname) 'Author Full Name', title 'Title Name'
FROM titles T JOIN titleauthor TA 
ON T.title_id = TA.title_id
JOIN authors A  ON A.au_id = TA.au_id
ORDER BY 1

--5) print the publisher name and the average advance for every publisher
SELECT P.pub_name 'Publisher Name', AVG(T.advance) 'Average Advance' 
FROM publishers P LEFT OUTER JOIN titles T 
ON P.pub_id = T.pub_id
GROUP BY P.pub_name
ORDER BY 1

--6) print the publishername, author name, title name and the sale amount(qty*price)
SELECT P.pub_name 'Publisher Name', CONCAT(A.au_fname, ' ', A.au_lname) 'Author Name', 
T.title 'Title Name',  S.qty*T.price 'Sale Amount'
FROM authors A JOIN titleauthor TA ON A.au_id = TA.au_id
JOIN titles T ON T.title_id = TA.title_id
JOIN publishers P ON P.pub_id = T.pub_id
JOIN sales S ON S.title_id = T.title_id
ORDER BY 1

--7) print the price of all that titles that have name that ends with s
SELECT title 'Title', price 'Price' FROM titles
WHERE title LIKE '%s'

--8) print the title names that contain 'and' in it
SELECT title 'Title' FROM titles
WHERE title LIKE '%and%'

--9) print the employee name and the publisher name
SELECT CONCAT(E.fname, ' ', E.lname) 'Employee Name', P.pub_name 'Publisher Name' 
FROM publishers P JOIN employee E
ON P.pub_id = E.pub_id
ORDER BY 2, 1

--10) print the publisher name and number of employees woking in it if the publisher has more than 2 employees
SELECT P.pub_name 'Publisher Name', COUNT(E.pub_id) 'No. of Employee'
FROM publishers P JOIN employee E
ON P.pub_id = E.pub_id
GROUP BY P.pub_name
HAVING COUNT(E.pub_id) > 2
ORDER BY 1

--11) Print the author names who have published using the publisher name 'Algodata Infosystems'
SELECT CONCAT(A.au_fname, ' ', A.au_lname) 'Author Name' FROM authors A 
JOIN titleauthor TA ON A.au_id = TA.au_id
JOIN titles T ON T.title_id = TA.title_id
JOIN publishers P ON P.pub_id = T.pub_id
WHERE P.pub_name = 'Algodata Infosystems'
ORDER BY 1

--12) Print the employees of the publisher 'Algodata Infosystems'
SELECT * FROM employee E JOIN publishers P
ON P.pub_id = E.pub_id
WHERE P.pub_name = 'Algodata Infosystems'
ORDER BY 1

--13)Create the following tables
--Employee(id-identity starts in 100 inc by 1, Name,age, phone cannot be null, gender)
--Salary(id-identity starts at 1 increments by 100, Basic,HRA,DA,deductions)
--EmployeeSalary(transaction_number int, employee_id-reference Employee's Id, Salary_id reference Salary Id,Date)
--PS - In the emeployee salary table transaction number is the primary key
--the combination of employee_id, salary_id and date should always be unique

--CREATE DATABASE dbSampleTutorialD3
 
USE dbSampleTutorialD3

CREATE TABLE Employee(
Emp_id INT IDENTITY(100,1) PRIMARY KEY,
Emp_name VARCHAR(20),
Emp_age INT,
Emp_phone VARCHAR(20) NOT NULL,
Emp_gender VARCHAR(20) CHECK (Emp_gender in ('Male', 'Female', 'Other')))

CREATE TABLE Salary(
Sal_id INT IDENTITY(100,1) PRIMARY KEY,
Sal_basic FLOAT,
Sal_HRA FLOAT,
Sal_DA FLOAT,
Sal_deductions FLOAT)

CREATE TABLE EmployeeSalary(
Tran_num INT IDENTITY(1,1) PRIMARY KEY,
Emp_id INT CONSTRAINT fk_empId FOREIGN KEY REFERENCES Employee(Emp_id),
Sal_id INT CONSTRAINT fk_salId FOREIGN KEY REFERENCES Salary(Sal_id),
Tran_date DATE,
UNIQUE (Emp_id, Sal_id, Tran_date)
)

--Add a column email-varchar(100) to the employee table
ALTER TABLE Employee ADD Emp_email VARCHAR(100)

--Insert few records in all the tables
INSERT INTO Employee VALUES('Aria', 20, '0123456789', 'Female', 'aria20@email.com')
INSERT INTO Employee VALUES('Bob', 22, '0113456789', 'Male', 'bob22@email.com')
INSERT INTO Employee VALUES('Carson', 22, '0111456789', 'Other', 'iamacar@email.com')

INSERT INTO Salary VALUES(5000,1000,1500,500)
INSERT INTO Salary VALUES(15000,400,600,550)
INSERT INTO Salary VALUES(10000,500,1000,50)

INSERT INTO EmployeeSalary VALUES(100,100,'2021-10-01')
INSERT INTO EmployeeSalary VALUES(101,101,'2021-10-02')
INSERT INTO EmployeeSalary VALUES(102,102,'2021-10-03')
INSERT INTO EmployeeSalary VALUES(100,102,'2021-10-04')

--Create a procedure which will print the total salary of employee by taking the employee id and the date
--total = Basic+HRA+DA-deductions
CREATE PROC sp_totalEmpSalary(
@Emp_id INT,
@date DATE
)
AS
BEGIN
	DECLARE 
	@Sal_id INT,
	@basic FLOAT,
	@HRA FLOAT,
	@DA FLOAT,
	@deductios FLOAT,
	@totalSal FLOAT

	SET @Sal_id = (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id AND Tran_date = @date)
	SET @basic = (SELECT Sal_basic FROM Salary WHERE Sal_id = @Sal_id)
	SET @HRA = (SELECT Sal_HRA FROM Salary WHERE Sal_id = @Sal_id)
	SET @DA = (SELECT Sal_DA FROM Salary WHERE Sal_id = @Sal_id)
	SET @deductios = (SELECT Sal_deductions FROM Salary WHERE Sal_id = @Sal_id)

	SET @totalSal = @basic + @HRA + @DA - @deductios
	
	PRINT 'Total Salary of Employee ID: ' + CAST(@Emp_id AS VARCHAR(20)) + ' is ' + CAST(@totalSal AS VARCHAR(20))
END

--Create a procedure which will calculate the average salary of an employee taking his ID
CREATE PROC sp_averageEmpSalary(
@Emp_id INT
)
AS
BEGIN
	DECLARE 
	@Sal_count INT,
	@Sal_id INT,
	@basic FLOAT,
	@HRA FLOAT,
	@DA FLOAT,
	@deductios FLOAT,
	@totalSal FLOAT,
	@averageSAL FLOAT

	SET @Sal_count = (SELECT COUNT(Sal_id) FROM EmployeeSalary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))

	IF (@Sal_count > 1)
	BEGIN
		SET @basic = (SELECT SUM(Sal_basic) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))
		SET @HRA = (SELECT SUM(Sal_HRA) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))
		SET @DA = (SELECT SUM(Sal_DA) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))
		SET @deductios = (SELECT SUM(Sal_deductions) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))

		SET @totalSal = @basic + @HRA + @DA - @deductios
		SET @averageSAL = @totalSal / @Sal_count
	END
	ELSE
	BEGIN
		SET @Sal_id = (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id)
		SET @basic = (SELECT Sal_basic FROM Salary WHERE Sal_id = @Sal_id)
		SET @HRA = (SELECT Sal_HRA FROM Salary WHERE Sal_id = @Sal_id)
		SET @DA = (SELECT Sal_DA FROM Salary WHERE Sal_id = @Sal_id)
		SET @deductios = (SELECT Sal_deductions FROM Salary WHERE Sal_id = @Sal_id)

		SET @totalSal = @basic + @HRA + @DA - @deductios
		SET @averageSAL = @totalSal
	END

	PRINT 'Average Salary of Employee ID: ' + CAST(@Emp_id AS VARCHAR(20)) + ' is ' + CAST(@averageSAL AS VARCHAR(20))

END

--Create a procedure which will catculate tax payable by employee
--Slabs as follows
--total < 100000 - 0%
--100000 < total < 200000 - 5%
--200000 < total < 350000 - 6%
--total > 350000 - 7.5%
CREATE PROC sp_calculateTaxPay(
@Emp_id INT)
AS
BEGIN
	DECLARE 
	@Sal_count INT,
	@Sal_id INT,
	@basic FLOAT,
	@HRA FLOAT,
	@DA FLOAT,
	@deductios FLOAT,
	@totalSal FLOAT,
	@taxPay FLOAT

	SET @basic = (SELECT SUM(Sal_basic) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))
	SET @HRA = (SELECT SUM(Sal_HRA) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))
	SET @DA = (SELECT SUM(Sal_DA) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))
	SET @deductios = (SELECT SUM(Sal_deductions) FROM Salary WHERE Sal_id IN (SELECT Sal_id FROM EmployeeSalary WHERE Emp_id = @Emp_id))

	SET @totalSal = @basic + @HRA + @DA - @deductios

	IF (@totalSal < 10000) -- 0%
	BEGIN
		SET @taxPay = 0
	END
	ELSE IF (@totalSal >10000 AND @totalSal < 20000) -- 5%
	BEGIN
		SET @taxPay = 0.05*@totalSal
	END
	ELSE IF (@totalSal >200000 AND @totalSal <350000) -- 6%
	BEGIN
		SET @taxPay = 0.06*@totalSal
	END
	ELSE IF (@totalSal >350000) -- 7.5%
	BEGIN
		SET @taxPay = 0.075*@totalSal
	END
	PRINT 'The Tax payable for the Employee ID: ' + CAST(@Emp_id AS VARCHAR(20)) + ' is ' + CAST(@taxPay AS VARCHAR(20))
END

--testing execution
EXEC sp_totalEmpSalary 100, '2021-10-01'

EXEC sp_averageEmpSalary 100

EXEC sp_calculateTaxPay 100

--14) Create a function that will take the basic,HRA and da returns the sum of the three
CREATE FUNCTION fn_sumOfThree(
@basic FLOAT, 
@da FLOAT, 
@hra FLOAT)
RETURNS FLOAT

AS
BEGIN
	RETURN @basic + @da + @hra
END

SELECT dbo.fn_sumOfThree(10,10,10)

--15) Create a cursor that will pick up every employee and print his details 
--then print all the entries for his salary in the employeesalary table. 
--Also show the salary splitt up(Hint-> use the salary table)
DECLARE
@Empl_id INT ,
@Empl_name VARCHAR(20),
@Empl_age INT,
@Empl_phone VARCHAR(20),
@Empl_gender VARCHAR(20),
@Empl_email VARCHAR(100)

DECLARE cur_employee CURSOR FOR SELECT * FROM Employee
OPEN cur_employee
FETCH NEXT FROM cur_employee INTO @Empl_id, @Empl_name, @Empl_age , @Empl_phone , @Empl_gender, @Empl_email 

WHILE (@@FETCH_STATUS = 0)
BEGIN
	PRINT 'Employee number: ' + CAST(@Empl_id AS VARCHAR(20))
	PRINT 'Employee name: ' + CAST(@Empl_name AS VARCHAR(20))
	PRINT 'Employee age: ' + CAST(@Empl_age AS VARCHAR(20))
	PRINT 'Employee phone: ' + CAST(@Empl_phone AS VARCHAR(20))
	PRINT 'Employee gender: ' + CAST(@Empl_gender AS VARCHAR(20))
	PRINT 'Employee email: ' + CAST(@Empl_email AS VARCHAR(20))
	PRINT '-----------------------------------------------------------'
	
		DECLARE 
		@ES_num INT,
		@ES_emp_id INT,
		@ES_sal_id INT,
		@ES_date DATE

		DECLARE cur_empSalary CURSOR FOR SELECT Tran_num, Sal_id, Tran_date FROM EmployeeSalary WHERE Emp_id = @Empl_id
		OPEN cur_empSalary
		FETCH NEXT FROM cur_empSalary INTO @ES_num ,@ES_sal_id ,@ES_date 

		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			PRINT '		Transaction number: ' + CAST(@ES_num AS VARCHAR(20))
			PRINT '		Salary ID: ' + CAST(@ES_sal_id AS VARCHAR(20))
			PRINT '		Transaction date: ' + CAST(@ES_date AS VARCHAR(20))
			PRINT '-----------------------------------------------------------'

			DECLARE 
			@Sala_basic FLOAT,
			@Sala_HRA FLOAT,
			@Sala_DA FLOAT,
			@Sala_deductions FLOAT

			DECLARE cur_salary CURSOR FOR SELECT Sal_basic, Sal_HRA, Sal_DA, Sal_deductions FROM Salary WHERE Sal_id = @ES_sal_id
			OPEN cur_salary
			FETCH NEXT FROM cur_salary INTO @Sala_basic ,@Sala_HRA ,@Sala_DA, @Sala_deductions 

			WHILE (@@FETCH_STATUS = 0)
				BEGIN
				PRINT '			Basic Salary: ' + CAST(@Sala_basic AS VARCHAR(20))
				PRINT '			HRA: ' + CAST(@Sala_HRA AS VARCHAR(20))
				PRINT '			DA: ' + CAST(@Sala_DA AS VARCHAR(20))
				PRINT '			Deductions: ' + CAST(@Sala_deductions AS VARCHAR(20))
				PRINT '-----------------------------------------------------------'

				FETCH NEXT FROM cur_salary INTO @Sala_basic ,@Sala_HRA ,@Sala_DA, @Sala_deductions 
			END

				CLOSE cur_salary
				DEALLOCATE cur_salary

			FETCH NEXT FROM cur_empSalary INTO @ES_num,@ES_sal_id ,@ES_date
		END

		CLOSE cur_empSalary
		DEALLOCATE cur_empSalary

	FETCH NEXT FROM cur_employee INTO @Empl_id, @Empl_name, @Empl_age , @Empl_phone , @Empl_gender, @Empl_email 

END

CLOSE cur_employee
DEALLOCATE cur_employee




