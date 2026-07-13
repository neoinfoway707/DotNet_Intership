SELECT
	d.name as Department ,
	e.name as Employee , 
	e.salary as Salary 
from Employee e 
JOIN Department d ON e.departmentId = d.id
JOIN (
    SELECT departmentId, MAX(salary) AS maxSalary
    FROM Employee
    GROUP BY departmentId
) AS maxTable ON e.departmentId = maxTable.departmentId
AND e.salary = maxTable.maxSalary;

--USING SUB-QUERY
SELECT
	d.name as Department ,
	e.name as Employee , 
	e.salary as Salary 
from Employee e, Department d 
WHERE e.departmentId = d.id
AND e.salary IN(
	SELECT MAX(salary) 
	FROM Employee 
	WHERE d.id = departmentId
);