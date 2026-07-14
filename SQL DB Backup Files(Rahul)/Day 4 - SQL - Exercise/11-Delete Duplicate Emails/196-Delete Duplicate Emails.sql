SELECT * FROM Person;

DELETE p1 FROM person p1 
JOIN Person p2 
ON p1.email = p2.email 
WHERE p1.id > p2.id;