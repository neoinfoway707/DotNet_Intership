SELECT * FROM MyNumbers;

SELECT MAX(maxNum) AS num 
FROM (
	SELECT 
		MAX(num) as maxNum
	FROM MyNumbers 
	GROUP BY num 
	HAVING COUNT(*) = 1
) as single;