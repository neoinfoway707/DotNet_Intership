select * from Person;

Select * from Address;

SELECT 
	p.firstName,
	p.LastName,
	a.city,
	a.state 
FROM Person p 
LEFT JOIN Address a
ON p.personId = a.personId;