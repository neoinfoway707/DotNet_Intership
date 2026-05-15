use Sqldb;
GO

--DROP TABLE IF EXISTS Employees;
--DROP TABLE IF EXISTS Department;

--CREATE TABLE Department(
--	Did INT IDENTITY(1,1) PRIMARY KEY,
--	Dname varchar(20)
--);
--GO

--create table Employees(
--	Eid int identity(1,1) PRIMARY KEY,
--	Enm varchar(50) not null,
--	Role varchar(20),
--	Did INT REFERENCES Department(Did) ON DELETE CASCADE,
--	Salary Decimal(10,2),
--	City varchar(20)
--);
--GO

--INSERT INTO Department (Dname) 
--VALUES
--	('IT'),
--	('HR'),
--	('Data Science'),
--	('Marketing');
--GO

--INSERT INTO Employees (Enm,Role,Did,Salary,City) 
--VALUES
--	('Rahul Parmar','Senior Developer', 1,'150000.00','Ahmedabad'),
--	('Krisha  Parmar','Manager',2,'120000.00','Ahmedabad'),
--	('Viraj Chauhan','Data Analyst',3,'100000.00','Mumbai'),
--	('Sneha Joshi','Marketing Executive',4,'70000.00','Mumbai'),
--	('Vijay Kumar','Intern',NULL,'30000.00','Delhi');
--GO

SELECT E.Enm AS 'Employee',E.Role AS 'Role',D.Dname AS 'Departemnt' 
FROM Employees E
LEFT JOIN Department D ON D.Did = E.Did WHERE E.City <> 'Mumbai';

SELECT E.Enm AS 'Employee',E.Role AS 'Role',D.Dname AS 'Departemnt' 
FROM Employees E
RIGHT JOIN Department D ON D.Did = E.Did ORDER BY E.Enm;
GO

SELECT E.Enm,D.Dname FROM Employees E FULL JOIN Department D ON E.Did = D.Did;

SELECT 
	E1.Enm AS 'Emp 1 Name',
	E1.Salary AS 'Emp 1 Salary',
	E2.Enm AS 'Emp 2 Name',
	E2.Salary AS 'Emp 1 Salary' 
FROM Employees E1, Employees E2  where
E1.City = E2.City And E1.Salary > E2.Salary;
GO

SELECT City AS 'Name' FROM Employees
UNION
SELECT Dname AS 'Name' FROM Department;

SELECT City, AVG(Salary) 
FROM Employees GROUP BY City
Having MAX(Salary) > (select AVG(Salary) FROM Employees)
Go

select Enm,Role,City FROM Employees WHERE Exists(SELECT Did FROM Department WHERE Did = Employees.Eid);

SELECT * FROM Employees WHERE Salary > ANY (SELECT Salary FROM Employees WHERE city = 'Ahmedabad');

SELECT * FROM Employees WHERE Salary > ALL
(SELECT Salary from Employees where City = 'Mumbai');
Go