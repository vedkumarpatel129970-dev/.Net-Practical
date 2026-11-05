CREATE DATABASE InventoryDB;
GO
USE InventoryDB;
GO

CREATE TABLE Products
(
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Category NVARCHAR(60) NOT NULL
);
GO

-- Optional sample records
INSERT INTO Products (ProductName, Quantity, Price, Category)
VALUES
('Wireless Mouse', 25, 599.00, 'Electronics'),
('Notebook', 4, 45.00, 'Stationery'),
('USB Keyboard', 18, 799.00, 'Electronics');
GO