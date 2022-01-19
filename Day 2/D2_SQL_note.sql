use Northwind

SELECT * FROM Products --select/project all

-----------------------
---------ALIAS---------
-----------------------

SELECT ProductName AS PM FROM Products --aliases
SELECT ProductName PM FROM Products --same but shorter

-----------------------
----PROJECT/SELECT-----
-----------------------

SELECT ProductID, ProductName FROM Products --selective select/project

SELECT * FROM Products WHERE UnitPrice >= 15 AND UnitPrice < 25 --selective/filter
SELECT * FROM Products WHERE UnitPrice BETWEEN 15 AND 25 -- between

SELECT * FROM Products WHERE SupplierID = 15 OR UnitsInStock < 5

SELECT * FROM Products WHERE UnitsInStock % 15 = 0 OR UnitsInStock < 5

SELECT * FROM Products Where SupplierID IN (8,12,13,18)

SELECT * FROM Products WHERE ProductName NOT IN ('Ikura','Chai')

--fuzzy logic -continuously filtering with every input 

SELECT * FROM Products WHERE ProductName LIKE '%C__'
-- % = 0 or many char
-- _ = only 1 character (can have multiple _)

SELECT * FROM Products WHERE ProductName LIKE '%on%'

-----------------------
------AGGREGATE--------
-----------------------

SELECT AVG(UnitsInStock) 'Average Unit In Stock' FROM Products --example of an aggregate function

SELECT 
AVG(UnitsInStock) 'Average Unit In Stock',
SUM(UnitsInStock) 'Sum of Unit In Stock'
FROM Products

--Print the average price of products that are supplied by
--supplier with id 2,6,9

SELECT AVG(UnitPrice) 'Average Price of Products' FROM Products WHERE SupplierID IN (2,6,9)

SELECT COUNT(SupplierID) FROM Products --wrong input

SELECT COUNT(DISTINCT SupplierID) FROM Products

SELECT APPROX_COUNT_DISTINCT(SupplierID) FROM Products

-----------------------
-------SORTING---------
-----------------------

SELECT * FROM Products ORDER BY SupplierID DESC --default is by Ascending order

SELECT * FROM Products ORDER BY SupplierID, UnitsInStock

SELECT * FROM Products ORDER BY SupplierID, UnitsInStock DESC

--Print all the products sorted by supplierid
--where the product name should contain 'e'

SELECT * FROM Products WHERE ProductName LIKE '%e%' ORDER BY SupplierID

SELECT SupplierId, COUNT(ProductID) 'No. of Products' FROM Products GROUP BY SupplierID

------------------------------------------------------------------------
--All this examples are the same with different "phrasing" for the order

SELECT SupplierId, COUNT(ProductID) 'No. of Products' 
FROM Products WHERE UnitsInStock > 0 
GROUP BY SupplierID
ORDER BY 'No. of Products'

SELECT SupplierId, COUNT(ProductID) 'No. of Products' 
FROM Products WHERE UnitsInStock > 0 
GROUP BY SupplierID
ORDER BY 2

SELECT SupplierId, COUNT(ProductID) 'No. of Products' 
FROM Products WHERE UnitsInStock > 0 
GROUP BY SupplierID
ORDER BY COUNT(ProductID)

------------------------------------------------------------------------

SELECT SupplierId, COUNT(ProductID) 'No. of Products' -- Projection
FROM Products				-- FROM Clause -> From <table>
WHERE UnitsInStock > 0      -- Selection / Filter
GROUP BY SupplierID         -- GROUP BY Clause -> For Projection mix with aggregate function
HAVING COUNT(ProductID) > 2 -- HAVING Clause -> Selection/Filter for aggreagate function
ORDER BY COUNT(ProductID)   -- Sort

--Print the average price of products sold by every salesperson
--if the average is grater than 3
--where the shipCountry is france and the customer name contains 'e'
--sort the result by the salesperson

SELECT * FROM Invoices

SELECT Salesperson, ROUND(AVG(UnitPrice),2) 'Average Unit Price' FROM Invoices 
WHERE ShipCountry = 'France' AND CustomerName LIKE '%e%'
GROUP BY Salesperson
HAVING AVG(UnitPrice) > 3
ORDER BY Salesperson

-----------------------
-------SUB_QUERY-------
-----------------------

SELECT * FROM Suppliers

SELECT SupplierId FROM Suppliers WHERE Country = 'Japan'

SELECT * FROM Products WHERE SupplierId in (4,6)

SELECT * FROM Products WHERE SupplierID IN
(SELECT SupplierID FROM Suppliers WHERE Country = 'Japan')

SELECT * FROM Products WHERE SupplierID IN
(SELECT SupplierID FROM Suppliers WHERE Country = 'Germany')

SELECT * FROM Products WHERE SupplierID =
(SELECT SupplierID FROM Suppliers WHERE CompanyName = 'Tokyo Traders')
--this only work as there are only 1 result/selection, preferably to use IN instead

--Select the average units in stock of products that are supplied by supplier
--whose region name is not null and the average is greater than 3
--sort the result by the average units

SELECT ProductID, AVG(UnitsInStock) 'Average Units in Stock' FROM Products WHERE SupplierID IN
(SELECT SupplierID FROM Suppliers WHERE Region IS NOT NULL)
GROUP BY ProductID
HAVING AVG(UnitsInStock) > 3
ORDER BY AVG(UnitsInStock)

--Select the product details which are from category with name that has 'pro' in it
--and the quantity in stock is greater than 0
-- sort the result by the unit price

SELECT * FROM Products WHERE CategoryID IN
(SELECT CategoryID FROM Categories WHERE CategoryName LIKE '%pro%')
AND UnitsInStock > 0
ORDER BY UnitPrice

--Nested Sub-Query
SELECT * FROM [Order Details]
WHERE ProductId IN 
(SELECT ProductId FROM Products WHERE CategoryID IN
(SELECT CategoryID FROM Categories WHERE CategoryName LIKE '%pro%')
)

-----------------------
---------JOINS---------
-----------------------

--3 Types = Inner, Outer, Cross

SELECT * FROM Products WHERE ProductID NOT IN
(SELECT DISTINCT ProductID FROM [Order Details])

-- INNER JOIN => Default (When using simply "join", it will be considered using inner join)
-- Combines more than one table into one based on a particular column (related)
-- will project only the related

SELECT ProductName, OD.UnitPrice, Quantity, OD.UnitPrice*Quantity 'Product Price'
FROM Products P JOIN [Order Details] OD --can also use INNER JOIN, same thing
ON P.ProductID = OD.ProductID
ORDER BY ProductName, Quantity

--instance name is different from alias, these are instance name
--the above example is also considered as an equal join

SELECT ContactName, OrderDate 
FROM Orders O INNER JOIN Customers C
ON O.CustomerID = C.CustomerID
ORDER BY ContactName

--this query is by the logic that if it exist on order detail, only then the customer never bought anything
SELECT ContactName 'Customer Name' FROM Customers 
WHERE CustomerID NOT IN
(SELECT CustomerID 
FROM Orders O INNER JOIN [Order Details] OD 
ON O.OrderID = OD.OrderID)

--OUTER JOIN
--will project the non-related as well (depends on left,right or full)

SELECT ContactName 'Customer Name', OrderDate 
FROM Customers C LEFT OUTER JOIN ORDERS O
ON C.CustomerID = O.CustomerID
ORDER BY 1
--the example above will include the customer who didnt make any order as well
--this is due to using left outer join which include non related as well
--for this scenario, using right outer join wont differ from inner join as orders always have CustomerID

SELECT CONCAT(FirstName,' ',LastName) 'Employee Name', COUNT(OrderID) 'No. of Order'
FROM Employees E JOIN Orders O
ON E.EmployeeID = O.EmployeeID
GROUP BY CONCAT(FirstName,' ',LastName)
HAVING COUNT(OrderID) > 50
ORDER BY 2

SELECT * FROM [Order Details]

--print the orderid and the product name, customer name
--order, order details, products, customers

SELECT C.ContactName 'Customer Name', O.OrderID, P.ProductName, OD.UnitPrice*OD.Quantity 'Price'
FROM Customers C JOIN Orders O
ON C.CustomerID = O.CustomerID
LEFT OUTER JOIN [Order Details] OD ON OD.OrderID = O.OrderID
LEFT OUTER JOIN Products P ON P.ProductID = OD.ProductID
ORDER BY PRICE

SELECT C.ContactName 'Customer Name', O.OrderID, P.ProductName, OD.UnitPrice*OD.Quantity 'Price'
FROM Products P JOIN [Order Details] OD 
ON P.ProductID = OD.ProductID
JOIN Orders O ON OD.OrderID = O.OrderID
RIGHT OUTER JOIN Customers C ON C.CustomerID = O.CustomerID
ORDER BY PRICE

--CROSS JOIN
--A cross join is a type of join that returns the Cartesian product of rows from the tables in the join. 
--In other words, it combines each row from the first table with each row from the second table.

SELECT * FROM Region CROSS JOIN Shippers
--it will combine and produce every outcome of the two table

--SELF JOIN
-- where a table relate to itself

SELECT Emp.EmployeeID 'Employee ID', Emp.FirstName 'Employee Name', 
Mgr.EmployeeID 'Manager ID', Mgr.FirstName 'Manager Name'
FROM Employees Emp JOIN Employees Mgr
ON Emp.ReportsTo = Mgr.EmployeeID
