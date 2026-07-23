SELECT * FROM RequestAccepted;

SELECT TOP (1) id, COUNT(*) AS num
FROM (
    SELECT requester_id AS id FROM RequestAccepted
    UNION ALL
    SELECT accepter_id AS id FROM RequestAccepted
) AS combined
GROUP BY id
ORDER BY num DESC;
--LIMIT 1;