SELECT * FROM Employee;

SELECT Max(salary) AS SecondHighestSalary 
FROM Employee 
WHERE salary < (SELECT Max(salary) FROM Employee);