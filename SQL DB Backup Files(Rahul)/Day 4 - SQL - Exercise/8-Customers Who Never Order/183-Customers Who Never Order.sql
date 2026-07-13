SELECT c.name AS Customers 
FROM Customers c 
LEFT JOIN Orders o 
ON o.customerId = c.Id 
WHERE o.customerId IS NULL;

--USING SUB QUERY
SELECT c.name AS Customers 
FROM Customers c 
WHERE c.Id NOT IN(SELECT customerId FROM Orders);