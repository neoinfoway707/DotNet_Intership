SELECT d.name AS Department, e.name AS Employee, e.salary AS Salary  
FROM Employee e, Department d 
WHERE salary IN (
    SELECT DISTINCT TOP(3) salary 
    FROM Employee 
    WHERE departmentId = d.id 
    ORDER BY salary DESC
) 
AND e.departmentId = d.id;


SELECT d.name AS Department, e.name AS Employee, e.salary AS Salary
FROM Department d
JOIN (
    SELECT 
        name, 
        departmentId, 
        salary,
        DENSE_RANK() OVER (PARTITION BY departmentId ORDER BY salary DESC) AS rnk 
    FROM Employee
) e ON e.departmentId = d.id
WHERE e.rnk <= 3 ;
