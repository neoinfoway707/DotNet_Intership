--Update Query Procedure
CREATE PROCEDURE UpdateMedicleSupply
	@ItemCode NVARCHAR(50),
    @ItemName NVARCHAR(50),
    @Category NVARCHAR(50),
    @UnitPrice DECIMAL(18,2),
    @QuantityInStock INT,
    @ExpiryDate DATETIME,
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE MedicalSupplies 
            SET ItemCode = @ItemCode, 
                ItemName = @ItemName,
                Category=@Category,
                UnitPrice=@UnitPrice,
                QuantityInStock=@QuantityInStock,
                ExpiryDate = @ExpiryDate 
            WHERE Id = @Id;
        
        COMMIT TRANSACTION;
        
        SELECT * FROM MedicalSupplies WHERE Id = @Id;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;
        THROW;
    END CATCH
END
GO

--Delete Query Procedure
CREATE PROCEDURE DeleteMedicleSupply
    @Id INT
AS 
BEGIN
SET NOCOUNT ON;
    BEGIN TRY

        BEGIN TRANSACTION;
            UPDATE MedicalSupplies SET IsActive = 0 WHERE Id = @Id;
        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;
        THROW;
    END CATCH
END
GO

--Insert Query Procedure
CREATE PROCEDURE CreateMedicleSupply
	@ItemCode NVARCHAR(50),
    @ItemName NVARCHAR(50),
    @Category NVARCHAR(50),
    @UnitPrice DECIMAL(18,2),
    @QuantityInStock INT,
    @ExpiryDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        INSERT INTO MedicalSupplies(ItemCode,ItemName,Category,UnitPrice,QuantityInStock,ExpiryDate) 
        VALUES (@ItemCode,@ItemName,@Category,@UnitPrice,@QuantityInStock,@ExpiryDate);
        
        SELECT * FROM MedicalSupplies WHERE Id = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;
        THROW;
    END CATCH
END
GO

--Select By Id Query Procedure
CREATE PROCEDURE GetMedicleSupplyId
	@Id INT
AS
BEGIN
	select * FROM MedicalSupplies WHERE	Id = @Id AND IsActive = 1;
END
GO

--Select Query with all filter, sorting and pagination
CREATE PROCEDURE GetMedicleSuppliesItems
	@Category NVARCHAR(50) = NULL,
	@MinPrice DECIMAL(18,2) = NULL,
	@MaxPrice DECIMAL(18,2) = NULL,
	@SortOrder NVARCHAR(10) = NULL,
	@SortBy NVARCHAR(50) = NULL,
	@PageNumber INT = 1,
	@PageSize INT = 10,
	@TotalCount INT OUTPUT
As
BEGIN
	SET NOCOUNT ON;

	SELECT @TotalCount = Count(*) FROM MedicalSupplies 
	Where IsActive = 1 
		AND (@Category IS NULL OR Category = @Category)
		AND (@MinPrice IS NULL OR UnitPrice >= @MinPrice)
		AND (@MaxPrice IS NULL OR UnitPrice <= @MaxPrice);
	
	SELECT * FROM MedicalSupplies 
	Where IsActive = 1 
		AND (@Category IS NULL OR Category = @Category)
		AND (@MinPrice IS NULL OR UnitPrice >= @MinPrice)
		AND (@MaxPrice IS NULL OR UnitPrice <= @MaxPrice)
	ORDER BY
		CASE WHEN LOWER(@SortOrder) = 'desc' AND LOWER(@SortBy) = 'unitprice' THEN UnitPrice END DESC,
		CASE WHEN LOWER(@SortOrder) != 'desc' AND LOWER(@SortBy) = 'unitprice' THEN UnitPrice END ASC,
		CASE WHEN LOWER(@SortOrder) = 'desc' AND LOWER(@SortBY) ='expirydate' THEN ExpiryDate END DESC,
		CASE WHEN LOWER(@SortOrder) != 'desc' AND LOWER(@SortBY) ='expirydate' THEN ExpiryDate END ASC,
		CASE WHEN LOWER(@SortOrder) = 'desc' AND LOWER(@SortBY) ='quantityinstock' THEN QuantityInStock END DESC,
		CASE WHEN LOWER(@SortOrder) != 'desc' AND LOWER(@SortBY) ='quantityinstock' THEN QuantityInStock END ASC,
		CASE WHEN @SortBy IS NULL THEN Id END ASC
	OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
