CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL, -- Foreign key to link to the User table
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(18, 2) NOT NULL,
    -- Add other required fields for order details
    -- For example: ShippingAddressID, BillingAddressID, Status, etc.
    ShippingAddressID INT NOT NULL, -- Foreign key to link to the Address table for shipping address
    BillingAddressID INT NOT NULL, -- Foreign key to link to the Address table for billing address
    Status NVARCHAR(100) NOT NULL DEFAULT 'Pending', -- Status of the order (e.g., Pending, Shipped, Delivered)
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME,
    IsActive BIT NOT NULL DEFAULT 1
);
