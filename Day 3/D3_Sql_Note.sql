USE Northwind

--------------------
-------INTRO--------
--------------------

BEGIN

	DECLARE --declaring variables
	@score INT, 
	@dob DATETIME,
	@name VARCHAR(20)

	SET @score = 100
	SET @dob = '1995-10-1'
	SET @name = 'Halim Rahman'

	PRINT 'Hello ' + @name
	PRINT @score

	--Selection => Determine which path to take (i.e. if,else) 
	IF (@score > 70) -- Most case, require BEGIN & END, exception if only 1 line
		PRINT 'Pass'
	ELSE
		PRINT 'Fail'
	PRINT 'My Date of Birth is ' + CAST(@dob AS VARCHAR(20))

END

BEGIN
	DECLARE @count INT

	SET @count = 0

	--Iteration => Repeat execution of a section of a code (i.e. while)
	WHILE(@count<10)
	BEGIN
		PRINT @count
		SET @count = @count + 1
	END
END

--------------------
---STORE PROCEDURE--
--------------------

--Stored Procedure
--A stored procedure is a set of Structured Query Language (SQL) statements with an assigned name, 
--which are stored in a relational database management system (RDBMS) as a group, 
--so it can be reused and shared by multiple programs.
 
--create print hello world sp
CREATE PROCEDURE proc_FirstProcedure --stored procedure
AS
BEGIN
	PRINT 'Hello frm procedure'
END

--exec the sp
EXEC proc_FirstProcedure

--create print selection sp
CREATE PROC proc_PrintResult (@score INT)
AS
BEGIN
	IF (@score > 70) 
		PRINT 'Pass'
	ELSE
		PRINT 'Fail'
END

--exec the sp
EXEC proc_PrintResult 90, 'Tim'

--alter print selection sp (also known as modify)
ALTER PROC proc_PrintResult (
@score INT,
@name VARCHAR(20))
AS
BEGIN
	IF (@score > 70) 
		PRINT 'Pass ' + @name
	ELSE
		PRINT 'Fail ' + @name
END

--create calculation sp
CREATE PROC proc_calculate(
@amount FLOAT,
@tax FLOAT OUT)
AS
BEGIN
	PRINT 'Calculating........'
	SET @tax = @amount *10.2/100
	PRINT 'Done'
END

--test excectuion of the sp
DECLARE @giventax FLOAT
EXEC proc_calculate 10000, @giventax OUT
print @giventax

ALTER PROC proc_PrintPayable(
@OrderNumber VARCHAR(5))
AS
BEGIN
	DECLARE
	@CustName VARCHAR(20),
	@Gross FLOAT,
	@Discount FLOAT,
	@Fright FLOAT,
	@NetPrice FLOAT

	SET @CustName = (SELECT ContactName FROM Customers WHERE CustomerID IN
					(SELECT CustomerID FROM Orders WHERE OrderID = @OrderNumber))

	PRINT 'Hello ' + @CustName

	SET @Gross = (SELECT SUM(UnitPrice*Quantity) FROM [Order Details] WHERE OrderID = @OrderNumber)
	SET @Discount = (SELECT SUM(Discount) FROM [Order Details] WHERE OrderID = @OrderNumber)

	IF (@Discount > 0)
		SET @Gross = @Gross - (@Gross*@Discount/100)

	SET @Fright =  (SELECT Freight FROM Orders WHERE OrderID = @OrderNumber)
	SET @NetPrice = @Gross + @Fright

	PRINT 'Gross Amount ' + CAST(@Gross AS VARCHAR(20))
	PRINT 'Fright Amount ' + CAST(@Fright AS VARCHAR(20))
	PRINT '--------------------------------------'
	PRINT 'Net Price ' + CAST(@NetPrice AS VARCHAR(20))

END

--exec the sp
EXEC proc_PrintPayable '10249'

--create select sp
CREATE PROC proc_FetchAllCustomers
AS
BEGIN
  SELECT * FROM Customers
END

--exec the sp
EXEC proc_FetchAllCustomers

--------------------
---TRANSACTION/SP---
--------------------

CREATE TABLE tblSimple(
f1 INT PRIMARY KEY,
f2 VARCHAR(20))

CREATE PROC proc_InsertIntoSimple(
@f1 INT,
@f2 VARCHAR(20))
AS
BEGIN
	INSERT INTO tblSimple VALUES (@f1, @f2)
END

EXEC proc_InsertIntoSimple 10, 'who'

SELECT * FROM tblSimple

CREATE TABLE tblStatus(
f1 INT,
msg VARCHAR(20))

BEGIN TRAN
	INSERT INTO tblSimple VALUES(102, 'Check Done')
	INSERT INTO tblStatus VALUES(102, 'Success')
	IF ((SELECT COUNT(f1) FROM tblSimple WHERE f1 = 102)>0)
		ROLLBACK
	ELSE
		COMMIT

SELECT * FROM tblSimple
SELECT * FROM tblStatus

ALTER PROC proc_Transaction(
@f1 INT, 
@f2 VARCHAR(20))
AS
BEGIN
	BEGIN TRAN
	DECLARE @count INT
	SET @count = (SELECT COUNT(f1) FROM tblSimple WHERE f2 = @f2)
		INSERT INTO tblSimple VALUES(@f1, @f2)
		INSERT INTO tblStatus VALUES(@f1, 'Success')
		IF (@count>0)
			ROLLBACK
		ELSE
			COMMIT
END

EXEC proc_Transaction 103, 'new'

--create a stored procedure that will calculate total salary
--take input of basic, Dearness allowance(da), House Rent Allowance(hra), deductions and the number of leaves
--if the number of leaves is more than 2, deduct the pay for the extra days and calculate the nett salary

-- Total Salary = Basic Salary + Dearness allowance + House Rent Allowance

CREATE PROC proc_calculateTotalSalary2 (
@basic FLOAT, 
@da FLOAT,
@hra FLOAT,
@deduction FLOAT,
@leave INT)

AS
BEGIN
	DECLARE @total FLOAT
	DECLARE @perDaySalary FLOAT

	SET @total = @basic + @da + @hra - @deduction
	SET @perDaySalary = @total/30

	IF (@leave>2)
		BEGIN
			SET @leave = @leave - 2
			SET @total = @total - (@perDaySalary*@leave)
		END	

	PRINT 'Calculating......'
	PRINT 'Total Salary ' + CAST(@total AS VARCHAR(20))

END

EXEC proc_calculateTotalSalary2 10000, 100, 100, 100, 3

--------------------
------FUNCTION------
--------------------

--simple scalar function
CREATE FUNCTION fn_Sample(@num INT)
RETURNS INT
AS
BEGIN
	RETURN @num*@num
END

--execute scalar function
SELECT dbo.fn_Sample(10)
SELECT dbo.fn_Sample(UnitPrice) FROM Products

--create calculate salary function
CREATE FUNCTION fn_CalSalTable(@basic FLOAT, @da FLOAT, @hra FLOAT, @deduction FLOAT, @numLeaves INT)
RETURNS @SalTable Table(
GrossAmount FLOAT,
LeaveDeductions FLOAT,
NetAmount FLOAT
)
AS
BEGIN
	DECLARE
		@nettSalary FLOAT,
		@grossSalary FLOAT
		
		SET @grossSalary = @basic + @da + @hra - @deduction
		
		IF(@numLeaves > 2)
		
		BEGIN
			DECLARE @perDaySal FLOAT
			SET @perDaySal = @grossSalary / 30
			SET @nettSalary = @grossSalary - ((@numLeaves -2)*@perDaySal)
			INSERT INTO @SalTable VALUES (@grossSalary,((@numLeaves -2)*@perDaySal),@nettSalary)
		END
		ELSE
		BEGIN
			SET @nettSalary = @grossSalary
			INSERT INTO @SalTable VALUES (@grossSalary,0,@nettSalary)
		END
		RETURN
END

SELECT * FROM dbo.fn_CalSalTable(10000,5000,3000,1500,4)

--------------------
------TRIGGERS------
--------------------

SELECT * FROM tblSimple
SELECT * FROM tblStatus

CREATE TRIGGER trg_InsertCheck
ON tblSimple
FOR INSERT
AS
BEGIN 
	PRINT 'Hello'
END

INSERT INTO TblSimple VALUES (105,'something new')

--to delete function/trigger/sp, simply drop <name>

CREATE TRIGGER trg_UpdateCheck
ON tblSimple
FOR UPDATE
AS
BEGIN 
	PRINT 'Hello'
END

CREATE TABLE account
(accno INT PRIMARY KEY,
balance FLOAT)

CREATE TABLE trans
(tranno INT PRIMARY KEY,
fromacc INT REFERENCES account(accno),
toacc INT REFERENCES account(accno),
amount FLOAT,
status VARCHAR(100))

INSERT INTO account VALUES(101,5000)
INSERT INTO account VALUES(102,1000)
INSERT INTO account VALUES(103,10000)

SELECT * FROM account
SELECT * FROM trans

ALTER TRIGGER trg_Transact
ON trans --table
FOR INSERT
AS
BEGIN
	DECLARE @bal FLOAT, @check FLOAT, @credit FLOAT
	SET @bal = (SELECT balance FROM account WHERE accno = (SELECT fromacc FROM inserted))
	SET @credit = (SELECT amount FROM inserted)
	SET @check = @bal - @credit
	IF (@check < 500)
		UPDATE trans SET status = 'Failed'  WHERE tranno = (SELECT tranno FROM inserted)
	ELSE
	BEGIN
		UPDATE account SET balance = @check WHERE accno = (SELECT fromacc FROM inserted)
		UPDATE account SET balance = balance + @credit WHERE accno = (SELECT toacc FROM inserted)
		UPDATE trans SET status = 'Success'  WHERE tranno = (SELECT tranno FROM inserted)
	END
END

INSERT INTO trans VALUES(1,101,102,500,null)

--------------------
------CURSORS-------
--------------------

DECLARE
@accountNo INT,
@Balance FLOAT

DECLARE cur_account CURSOR FOR SELECT * FROM account

OPEN cur_account

FETCH NEXT FROM cur_account INTO @accountNo, @Balance

WHILE (@@FETCH_STATUS = 0)
BEGIN
	PRINT 'Account number: ' + CAST(@accountNo AS VARCHAR(20))
	PRINT 'Account balance: ' + CAST(@Balance AS VARCHAR(20))
	PRINT '---------------------------------'
	
		DECLARE @amount FLOAT, @status VARCHAR(20)
		DECLARE cur_tran CURSOR FOR SELECT amount, status FROM trans WHERE fromacc = @accountNo

		OPEN cur_tran

		FETCH NEXT FROM cur_tran INTO @amount, @status

		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			PRINT '				Amount Transferred: ' + CAST(@amount AS VARCHAR(20))
			PRINT '				Transaction Status: ' + CAST(@status AS VARCHAR(20))
			PRINT '---------------------------------'

			FETCH NEXT FROM cur_tran INTO @amount, @status
		END

		CLOSE cur_tran
		DEALLOCATE cur_tran

	FETCH NEXT FROM cur_account INTO @accountNo, @Balance

END

CLOSE cur_account
DEALLOCATE cur_account