CREATE TABLE tblPizzas
( id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(20),
IsVeg BIT,
price FLOAT
)

CREATE PROC proc_InsertPizza 
(@pname VARCHAR(20),
@veg BIT,
@pprice FLOAT)
AS
BEGIN
	INSERT INTO tblPizzas(name,isVeg,price) VALUES (@pname,@veg,@pprice)
END

CREATE PROC proc_UpdatePizzaPrice
(@pid INT, @pprice FLOAT)
AS
BEGIN
	UPDATE tblPizzas SET price = @pprice WHERE id = @pid
END

CREATE PROC proc_GetPizzaByID(@pid INT)
AS
BEGIN
	SELECT * FROM tblPizzas WHERE id = @pid
END