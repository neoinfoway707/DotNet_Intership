use Sqldb;
GO
--DROP TABLE IF EXISTS Employee
--CREATE TABLE Employee(
--	Eid int identity(1,1) primary key,
--	EmployeeName varchar(50) not null,
--	Department varchar(20) not null,
--	Role varchar(20) not null,
--	Salary decimal(10,2) not null,
--	City varchar(20) not null
--);
--GO

--INSERT INTO Employee(EmployeeName,Department,Role,Salary,City)
--	VALUES('Krisha Parmar','HR','Manager',120000.00,'Rajkot');
--INSERT INTO Employee(EmployeeName,Department,Role,Salary,City)
--	VALUES('Rahul Parmar','IT','Senior Developer',150000.00,'Rajkot');
--INSERT INTO Employee(EmployeeName,Department,Role,Salary,City)
--	VALUES('Amit Sharma','IT','Developer',85000.00,'Mumbai');
--INSERT INTO Employee(EmployeeName,Department,Role,Salary,City)
--	VALUES('Sneha Joshi','Sales','Executive',70000.00,'Mumbai');
--INSERT INTO Employee(EmployeeName,Department,Role,Salary,City)
--	VALUES('Vijay Kumar','IT','Junior Developer',45000.00,'Delhi');
--GO

SELECT TOP 2 * FROM Employee WHERE City In('Rajkot','Surat') ORDER BY EmployeeName;

SELECT TOP 40 PERCENT * FROM Employee ORDER BY Salary DESC;

SELECT Department,SUM(Salary) AS 'Total Salary' FROM Employee GROUP BY Department;

SELECT City,Count(Department) AS 'Number of Department' FROM Employee GROUP BY City;

SELECT Department, Avg(Salary)  AS 'Average Salary' ,Count(Department) AS 'Total Department' 
FROM Employee GROUP BY Department;
GO

SELECT City,MAX(Salary) AS 'Maximum Salary' FROM Employee 
WHERE Salary > (select AVG(Salary) FROM Employee) 
GROUP BY City;

SELECT * FROM Employee WHERE City LIKE 'r%';

SELECT * FROM Employee WHERE EmployeeName LIKE '%_P%';

SELECT * FROM Employee WHERE Role LIKE '[MS]%';

SELECT * FROM Employee WHERE Salary BETWEEN 100000 AND 150000;
GO