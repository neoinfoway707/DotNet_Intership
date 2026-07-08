IF OBJECT_ID('dbo.getNthHighestSalary') IS NOT NULL
    DROP FUNCTION dbo.getNthHighestSalary;

--GO
--CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
--BEGIN
--    DECLARE M INT;
--    SET M = N - 1;
--    RETURN (
--        # Write your MySQL query statement below.
--        SELECT IFNULL(
--            (SELECT DISTINCT salary 
--                FROM Employee 
--                ORDER BY salary DESC
--                LIMIT 1 OFFSET M
--            ),NULL
--        )
--    );
--END

GO
CREATE FUNCTION getNthHighestSalary(@N INT)
RETURNS INT
AS
BEGIN
	DECLARE @Result INT;
	DECLARE @Count INT;
	SELECT @Count = COUNT( distinct salary)from Employee;
	If @N > @Count 
		Return NUll;
	SELECT @Result = MIN(salary)
		FROM (
			SELECT DISTINCT TOP(@N) salary
			FROM Employee
			ORDER BY salary DESC
		) AS temp;

  RETURN @Result;
END;
GO

SELECT dbo.getNthHighestSalary(2);