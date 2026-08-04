SELECT * FROM Delivery;

SELECT ROUND(
    (SUM(CASE WHEN d1.first_order_date = d2.customer_pref_delivery_date THEN 1.0 
        ELSE 0.0 END) / COUNT(*)
    ) * 100 , 2) as immediate_percentage 
FROM (
    SELECT customer_id, MIN(order_date) AS first_order_date
    FROM Delivery
    GROUP BY customer_id
) d1
JOIN Delivery d2 
ON d2.customer_id = d1.customer_id AND d2.order_date = d1.first_order_date;