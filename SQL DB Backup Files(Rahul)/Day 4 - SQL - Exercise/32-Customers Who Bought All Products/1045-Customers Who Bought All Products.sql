SELECT * FROM Customer;
SELECT * FROM Product;

SELECT c.customer_id 
FROM Customer c
CROSS JOIN (
    SELECT COUNT(*) AS total_products 
    FROM Product
) p
GROUP BY c.customer_id, p.total_products
HAVING COUNT(DISTINCT c.product_key) = p.total_products;
