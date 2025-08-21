-- Create a database named saledb
CREATE DATABASE saledb;

GO

-- Create a table named ProductSales
Use saledb;
Go
CREATE TABLE ProductSales (
	SaleID INT Primary Key,
	ProductCode NVARCHAR(20),
	ProductName NVARCHAR(100),
	Quantity INT,
	UnitPrice DECIMAL(18,2),
	SaleDate DATE
);

Go

-- Inserting 
INSERT INTO ProductSales (SaleID, ProductCode,ProductName, Quantity, UnitPrice, SaleDate) Values 
	(1, 'P001', 'Pen', 10, 1.50, '2025-06-20'), 
	(2, 'P001', 'Pen', 5, 1.50, '2025-06-25'), 
	(3, 'P002', 'Notebook', 3, 3.20, '2025-06-21'), 
	(4, 'P003', 'Eraser', 15, 0.80, '2025-06-22');


GO
-- Create store procedure for retrieve all sales base on range date ,OR product name ( optional )
CREATE PROCEDURE sp_GetSalesByDate
    @StartDate DATE,
    @EndDate DATE,
    @ProductName NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ProductCode,
        ProductName,
        Quantity,
        UnitPrice,
        SaleDate
    FROM ProductSales
    WHERE SaleDate BETWEEN @StartDate AND @EndDate
      AND (@ProductName IS NULL OR ProductName LIKE '%' + @ProductName + '%')
    ORDER BY ProductCode, SaleDate;
END
