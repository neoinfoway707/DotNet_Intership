SELECT * FROM Stadium;

WITH RankedStadium AS (
    SELECT id, visit_date, people, 
        id - ROW_NUMBER() OVER (ORDER BY visit_date) AS rowId
    FROM Stadium 
    WHERE people >= 100
),
rowIdCounts AS (
    SELECT id, visit_date, people, 
        COUNT(*) OVER (PARTITION BY rowId) AS group_size
    FROM RankedStadium
)
SELECT id, visit_date, people
FROM rowIdCounts
WHERE group_size >= 3
ORDER BY visit_date;