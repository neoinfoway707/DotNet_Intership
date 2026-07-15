SELECT * FROM Trips;
SELECT * FROM Users;

SELECT 
    t.request_at AS 'Day',
    ROUND(
        SUM(CASE WHEN t.status LIKE 'cancelled%' THEN 1.0 ELSE 0.0 END) / COUNT(*), 
        2
    ) AS 'Cancellation Rate'
FROM Trips t 
JOIN Users client 
    ON t.client_id = client.users_id 
    AND client.banned = 'No' 
JOIN Users driver 
    ON t.driver_id = driver.users_id 
    AND driver.banned = 'No'
WHERE 
   t.request_at BETWEEN '2013-10-01' AND '2013-10-03'
GROUP BY t.request_at;