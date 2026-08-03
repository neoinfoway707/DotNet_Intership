SELECT * FROM Products;

SELECT d.product_id, 
       COALESCE(p.new_price, 10) AS price
FROM (
    SELECT DISTINCT product_id FROM Products
) AS d
LEFT JOIN (
    SELECT p.product_id, p.new_price, p.change_date 
    FROM Products p 
    JOIN (
        SELECT product_id, MAX(change_date) AS max_date
        FROM Products 
        WHERE change_date <= '2019-08-16'
        GROUP BY product_id
    ) AS t 
    ON p.product_id = t.product_id 
    AND p.change_date = t.max_date
) AS p
ON d.product_id = p.product_id;
