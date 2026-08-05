SELECT * FROM Prices;
SELECT * FROM UnitsSold;

SELECT 
	p.product_id,
	COALESCE(ROUND(SUM(u.units * p.price) * 1.0 / SUM(u.units) , 2) , 0) as average_price 
FROM Prices p
LEFT JOIN UnitsSold u ON 
	u.purchase_date BETWEEN p.start_date AND p.end_date 
	AND p.product_id = u.product_id
GROUP BY p.product_id;
