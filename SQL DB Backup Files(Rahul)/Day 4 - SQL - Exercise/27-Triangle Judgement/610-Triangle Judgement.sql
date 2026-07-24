SELECT * FROM Triangle;

SELECT x, y, z,
	CASE
		WHEN 
			(x + y) > z AND 
			(x + z) > y AND 
			(y+z) > x THEN 'YES'
		ELSE 'NO'
	END AS triangle
FROM Triangle;