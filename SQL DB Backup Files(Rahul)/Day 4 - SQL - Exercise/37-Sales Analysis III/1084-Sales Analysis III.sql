SELECT * FROM Product;
SELECT * FROM Sales;

SELECT product_id, product_name 
FROM Product
WHERE product_id NOT IN (
    SELECT product_id 
    FROM Sales
    WHERE sale_date NOT BETWEEN '2019-01-01' AND '2019-03-31'
)
AND product_id IN (
    SELECT product_id 
    FROM Sales
    WHERE sale_date BETWEEN '2019-01-01' AND '2019-03-31'
);

SELECT p.product_id, p.product_name
FROM Product AS p
JOIN Sales AS s
ON p.product_id = s.product_id
GROUP BY p.product_id, p.product_name
HAVING MIN(s.sale_date) >= '2019-01-01' AND MAX(s.sale_date) <= '2019-03-31';