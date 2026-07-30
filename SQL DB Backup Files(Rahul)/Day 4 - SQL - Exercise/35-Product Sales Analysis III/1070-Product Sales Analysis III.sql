SELECT * FROM Sales;

SELECT s.product_id, year.first_year, s.quantity, s.price 
FROM Sales s
JOIN (
    SELECT product_id, MIN(year) AS first_year
    FROM Sales
    GROUP BY product_id
) AS year 
ON s.year = year.first_year AND s.product_id = year.product_id;