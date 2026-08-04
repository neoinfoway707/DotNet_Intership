SELECT * FROM Queue;

WITH total AS (
    SELECT person_name, 
    SUM(weight) OVER (ORDER BY turn) AS Total_Weight 
	FROM Queue
)
SELECT TOP 1 t.person_name FROM total AS t
WHERE t.Total_Weight <= 1000
ORDER BY t.Total_Weight DESC;

--For Leetcode(MySQL)
-- SELECT t.person_name FROM (
-- 	SELECT 
-- 		person_name, 
-- 		SUM(weight) OVER (ORDER BY turn) AS Total_Weight 
-- 	FROM Queue
-- ) AS t
-- WHERE t.Total_Weight <= 1000
-- ORDER BY Total_Weight DESC
-- LIMIT 1;

--WITH total AS (
--    SELECT person_name, 
--    SUM(weight) OVER (ORDER BY turn) AS Total_Weight 
--	FROM Queue
--)
--SELECT t.person_name FROM total AS t
--WHERE t.Total_Weight <= 1000
--ORDER BY t.Total_Weight DESC
--LIMIT 1;