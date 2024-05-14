CREATE TABLE Ingredients (
    IngredientsID INT PRIMARY KEY IDENTITY,
    IngredientsName NVARCHAR(100) NOT NULL,
    IngredientsDescription NVARCHAR(MAX),
    IngredientsPrice DECIMAL(18, 2) NOT NULL,
    IngredientsTags NVARCHAR(100),
    IngredientsDiscount DECIMAL(18, 2) DEFAULT 0,
    IngredientsGender NVARCHAR(20),
    IngredientsImageURL NVARCHAR(255),
    IngredientsCreatedDate DATETIME DEFAULT GETDATE(),
    IngredientsIsActive BIT DEFAULT 1
);

