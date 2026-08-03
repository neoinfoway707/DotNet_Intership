SELECT * FROM Users;
SELECT * FROM Orders;
SELECT * FROM Items;

SELECT u.user_id AS buyer_id,
	u.join_date, 
	Count(o.order_date) AS orders_in_2019
FROM Users u
LEFT JOIN Orders o 
ON u.user_id = o.buyer_id AND YEAR(o.order_date) = '2019' 
GROUP BY u.user_id, u.join_date;