SELECT * FROM Department;

SELECT id,
	MAX(CASE WHEN month='Jan' THEN revenue ELSE NULL END) as Jan_Revenue,
	MAX(CASE WHEN month='Feb' THEN revenue ELSE NULL END) as Feb_Revenue,
	MAX(CASE WHEN month='Mar' THEN revenue ELSE NULL END) as Mar_Revenue,
	MAX(CASE WHEN month='Apr' THEN revenue ELSE NULL END) as Apr_Revenue,
	MAX(CASE WHEN month='May' THEN revenue ELSE NULL END) as May_Revenue,
	MAX(CASE WHEN month='Jun' THEN revenue ELSE NULL END) as Jun_Revenue,
	MAX(CASE WHEN month='Jul' THEN revenue ELSE NULL END) as Jul_Revenue,
	MAX(CASE WHEN month='Aug' THEN revenue ELSE NULL END) as Aug_Revenue,
	MAX(CASE WHEN month='Sep' THEN revenue ELSE NULL END) as Sep_Revenue,
	MAX(CASE WHEN month='Oct' THEN revenue ELSE NULL END) as Oct_Revenue,
	MAX(CASE WHEN month='Nov' THEN revenue ELSE NULL END) as Nov_Revenue,
	MAX(CASE WHEN month='Dec' THEN revenue ELSE NULL END) as Dec_Revenue
FROM Department
GROUP BY id;