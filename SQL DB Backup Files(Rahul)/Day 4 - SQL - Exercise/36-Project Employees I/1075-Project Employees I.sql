SELECT * FROM Project;
SELECT * FROM Employee;

SELECT p.project_id, 
	ROUND(AVG(CAST(t.experience_years AS FLOAT)), 2) AS average_years
FROM Project p 
JOIN Employee t ON p.employee_id = t.employee_id
GROUP BY p.project_id;
