CREATE TABLE Address (
    AddressID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL, -- Assuming UserID is a foreign key to link to the User table
    Address1 NVARCHAR(255) NOT NULL,
    Address2 NVARCHAR(255),
    Email NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    ZipCode NVARCHAR(20) NOT NULL,
    State NVARCHAR(100) NOT NULL,
    -- Other required fields for shipping
    ShippingMethod NVARCHAR(100) NOT NULL, -- Example: Standard, Express, etc.
    DeliveryInstructions NVARCHAR(MAX),
    -- Add more fields as needed
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME,
    IsActive BIT NOT NULL DEFAULT 1
);
