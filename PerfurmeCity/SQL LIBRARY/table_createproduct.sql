use perfurmdb

--drop table  Products
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Tags NVARCHAR(255),
    Price DECIMAL(10, 2) NOT NULL,
	 productIsActive bit,
    Discount DECIMAL(10, 2) DEFAULT 0,
    Gender NVARCHAR(50),
    ImageUrl NVARCHAR(MAX),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);