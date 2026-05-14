--create database Sqldb;
--GO

use Sqldb;
GO

--drop database SqldbTask;
--GO

--create table Stud(
--id int primary key,
--name varchar(50) not null,
--rollno int not null
--);
--GO

--create table Customer(
--	id int identity(1,1) primary key,
--	FirstName varchar(50) Not Null,
--	LastName varchar(50) Not Null,
--	address varchar(100) Not Null,
--	city varchar(20) Not Null
--);
--GO

--drop table if exists Stud;
--GO

--ALTER TABLE Customer ADD State varchar(20);
--EXEC sp_rename 'Customer.State','Country','Column'
--GO

--ALTER TABLE Customer ALTER COLUMN Country varchar(10);
--GO

--EXEC sp_rename 'Customer','Customers';
--ALTER TABLE Customers DROP COLUMN Country;
--GO

--ALTER TABLE  Customers ADD CONSTRAINT chk_Id CHECK(id > 0);
--GO

--create Table Product(
--id int identity(1,1) primary key,
--Pnm varchar(20),
--Price Float
--);
--Go

--ALTER TABLE Product ADD CId int;
--ALTER TABLE Product ADD CONSTRAINT fk_CId FOREIGN KEY (CId) REFERENCES Customers(id);
--GO

--INSERT INTO Customers(FirstName,LastName,address,city) 
--	VALUES('Dev','Chauhan','New Indira Nagar ,Rajkot, 370008','New Delhi');
--INSERT INTO Customers(FirstName,LastName,address,city) 
	--VALUES('Jay','Kacha','K.H. Malviya chock , M.G. Road ,Pune, 356789','Pune');
--INSERT INTO Customers(FirstName,LastName,address,city) 
--	VALUES('Dhruv','Pau','Old Guru nagar,Surat, 378758','New Mumbai');
--GO

--INSERT INTO Product (Pnm,Price,CId) VALUES('Rolex Daytona',1705000000.00,1);
--INSERT INTO Product (Pnm,Price,CId) VALUES('New City Game',770000.00,2);
--INSERT INTO Product (Pnm,Price,CId) VALUES('New City Game',770000.00,3);
--GO

select * from Customers where id IN(select CId from Product );
select * from Product where CId In(select id from Customers);

select DISTINCT Pnm,Price from Product where CId In(select id from Customers);

select * from Customers order by LastName DESC;

select c.FirstName AS Name,p.Pnm AS ProductName from customers c ,Product p where c.id = p.CId AND p.price > 7000000;
GO

select DISTINCT (c.FirstName+' '+ c.LastName) AS Name, p.Pnm AS Product, p.Price AS Price 
	from Customers c,Product p where p.CId = c.id AND (p.Pnm='New City Game' Or NOT p.Price >700000);
GO