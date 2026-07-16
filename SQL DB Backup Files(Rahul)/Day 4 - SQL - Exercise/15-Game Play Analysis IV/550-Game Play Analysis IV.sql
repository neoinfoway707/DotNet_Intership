SELECT * FROM Activity;


SELECT 
    ROUND(COUNT(a.event_date) * 1.0 / COUNT(f.first_login), 2) AS fraction 
FROM 
    (
        SELECT player_id, MIN(event_date) AS first_login 
        FROM Activity 
        GROUP BY player_id
    ) AS f
LEFT JOIN 
    Activity AS a ON f.player_id = a.player_id 
    AND a.event_date = DATEADD(day,1,f.first_login);
