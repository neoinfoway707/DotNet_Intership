SELECT * FROM Activity;

--FOR LEETCODE
--SELECT activity_date AS 'day',
--	COUNT(DISTINCT user_id) AS 'active_users' 
--FROM Activity 
--WHERE activity_date 
--BETWEEN DATE_SUB('2019-07-27',INTERVAL 29 DAY) AND '2019-07-27'
--GROUP BY activity_date ;

--FOR SSMS
SELECT activity_date AS 'day',
	count(distinct user_id) AS 'active_users' 
FROM Activity 
WHERE activity_date 
BETWEEN DATEADD(day, -29, '2019-07-27') AND '2019-07-27'
GROUP BY activity_date ;