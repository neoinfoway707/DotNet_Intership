select * from Employee;

SELECT e.name FROM Employee e 
JOIN
(
    SELECT managerId, Count(managerId) AS manager 
    FROM Employee 
    GROUP BY managerId 
    HAVING Count(managerId) >= 5
) AS m 
ON e.id = m.managerId;