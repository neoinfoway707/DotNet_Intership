SELECT * FROM Customer;

WITH total_daily_amount AS (
    SELECT 
        visited_on, 
        SUM(amount) AS daily_sum
    FROM Customer 
    GROUP BY visited_on
),
total_amount AS (
    SELECT visited_on, 
        SUM(daily_sum) OVER (
            ORDER BY visited_on 
            ROWS BETWEEN 6 PRECEDING AND CURRENT ROW
        ) AS amount ,
        ROW_NUMBER() OVER (ORDER BY visited_on)  AS row_num
    FROM total_daily_amount
)
SELECT visited_on, amount, ROUND(amount * 1.0 / 7, 2) AS average_amount 
FROM total_amount
WHERE row_num >= 7;