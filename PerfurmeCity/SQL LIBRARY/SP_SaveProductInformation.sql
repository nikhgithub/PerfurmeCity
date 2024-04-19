CREATE PROCEDURE SP_InsertProductV2
    @ProductName NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Tags NVARCHAR(255),
    @Price DECIMAL(10, 2),
    @Discount DECIMAL(10, 2),
    @Gender NVARCHAR(50),
    @ImageUrl NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Products (ProductName, Description, Tags, Price, Discount, Gender, ImageUrl, CreatedDate)
    VALUES (@ProductName, @Description, @Tags, @Price, @Discount, @Gender, @ImageUrl, GETDATE());
END;
