SELECT * FROM Cinema;

SELECT * FROM Cinema 
WHERE 
	Id % 2 = 1 AND 
	description != 'boring' 
ORDER BY rating DESC;