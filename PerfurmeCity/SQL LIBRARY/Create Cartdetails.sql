CREATE TABLE CartDetails (
    CartDetailID INT PRIMARY KEY IDENTITY,
    UserID NVARCHAR(50) NOT NULL,
    IngredientID INT NOT NULL,
    Quantity INT NOT NULL,
    AddedDate DATETIME NOT NULL DEFAULT GETDATE()
);

select * from CartDetails