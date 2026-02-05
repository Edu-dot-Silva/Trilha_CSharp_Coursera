-- Projeto: SmartShop Inventory System
-- Entregáveis: Basic, Complex, Debug/Otimização, Indexação

-- (Basic) Consulta todos os produtos
SELECT 
    ProductName,
    Category,
    Price,
    StockLevel
FROM Products;

-- (Basic) Consulta produtos da categoria 'Electronics'
SELECT 
    ProductName,
    Category,
    Price,
    StockLevel
FROM Products
WHERE Category = 'Electronics';

-- (Basic) Consulta produtos com estoque baixo
SELECT 
    ProductName,
    Category,
    Price,
    StockLevel
FROM Products
WHERE StockLevel < 10;

-- (Basic) Consulta produtos ordenados por preço
SELECT 
    ProductName,
    Category,
    Price,
    StockLevel
FROM Products
ORDER BY Price ASC;

-- (Basic) Consulta produtos de 'Clothing' com estoque baixo, ordenados por preço
SELECT 
    ProductName,
    Category,
    Price,
    StockLevel
FROM Products
WHERE Category = 'Clothing'
  AND StockLevel < 10
ORDER BY Price ASC;

-- (Complex) Consulta vendas com JOIN entre Products, Sales e Suppliers
SELECT 
    p.ProductName,
    s.SaleDate,
    s.StoreLocation,
    s.UnitsSold
FROM Products p
JOIN Sales s ON p.ProductID = s.ProductID
JOIN Suppliers sup ON p.SupplierID = sup.SupplierID;

-- (Complex) Consulta total de unidades vendidas por produto (subquery)
SELECT 
    p.ProductName,
    (SELECT SUM(s.UnitsSold)
     FROM Sales s
     WHERE s.ProductID = p.ProductID) AS TotalUnitsSold
FROM Products p;

-- (Complex) Consulta total de unidades vendidas por produto (JOIN + GROUP BY)
SELECT 
    p.ProductName,
    SUM(s.UnitsSold) AS TotalUnitsSold
FROM Products p
JOIN Sales s ON p.ProductID = s.ProductID
GROUP BY p.ProductName;

-- (Complex) Consulta fornecedores com entregas atrasadas (JOIN + GROUP BY + WHERE)
SELECT 
    sup.SupplierName,
    COUNT(d.DeliveryID) AS TotalDelayedDeliveries
FROM Suppliers sup
JOIN Deliveries d ON sup.SupplierID = d.SupplierID
WHERE d.DelayedDays > 0
GROUP BY sup.SupplierName
ORDER BY TotalDelayedDeliveries DESC;

-- (Complex) Consulta média de unidades vendidas por produto
SELECT 
    p.ProductName,
    AVG(s.UnitsSold) AS AverageUnitsPerSale
FROM Products p
JOIN Sales s ON p.ProductID = s.ProductID
GROUP BY p.ProductName;

-- (Complex) Consulta máximo de unidades vendidas em uma venda por produto
SELECT 
    p.ProductName,
    MAX(s.UnitsSold) AS MaxUnitsSoldInOneSale
FROM Products p
JOIN Sales s ON p.ProductID = s.ProductID
GROUP BY p.ProductName;

-- (Complex) Consulta estoque total de cada produto em todas as lojas
SELECT 
    p.ProductName,
    SUM(i.StockLevel) AS TotalStockAllStores
FROM Products p
JOIN Inventory i ON p.ProductID = i.ProductID
GROUP BY p.ProductName;

-- (Complex) Consulta vendas por loja e data, ordenando por data
SELECT 
    s.StoreLocation,
    s.SaleDate,
    SUM(s.UnitsSold) AS TotalSold
FROM Sales s
GROUP BY s.StoreLocation, s.SaleDate
ORDER BY s.SaleDate DESC;

-- (Complex) Consulta produtos com vendas acima da média (nested query)
SELECT ProductName
FROM Products
WHERE ProductID IN (
    SELECT ProductID
    FROM Sales
    GROUP BY ProductID
    HAVING SUM(UnitsSold) > (
        SELECT AVG(Total)
        FROM (
            SELECT SUM(UnitsSold) AS Total
            FROM Sales
            GROUP BY ProductID
        ) AS Media
    )
);

-- (Debug/Otimização) Indexação para melhorar performance de consultas
CREATE INDEX idx_sales_product ON Sales(ProductID);
CREATE INDEX idx_sales_date ON Sales(SaleDate);
CREATE INDEX idx_products_supplier ON Products(SupplierID);
CREATE INDEX idx_sales_store_date ON Sales(StoreLocation, SaleDate);

-- (Debug/Otimização) Consulta vendas por loja e data após indexação
SELECT 
    StoreLocation,
    SaleDate,
    SUM(UnitsSold) AS Total
FROM Sales
WHERE SaleDate >= '2024-01-01'
GROUP BY StoreLocation, SaleDate;

-- (Debug/Otimização) Consulta fornecedores com entregas atrasadas após indexação
SELECT 
    sup.SupplierName,
    COUNT(d.DeliveryID) AS Delays
FROM Suppliers sup
JOIN Deliveries d ON sup.SupplierID = d.SupplierID
WHERE d.DelayedDays > 0
GROUP BY sup.SupplierName
ORDER BY Delays DESC;

-- (Debug/Otimização) Consulta estoque total de cada produto após indexação
SELECT 
    p.ProductName,
    SUM(i.StockLevel) AS TotalStock
FROM Products p
JOIN Inventory i ON p.ProductID = i.ProductID
GROUP BY p.ProductName;

-- Fim do arquivo
-- Copilot auxiliou na geração, otimização e debug de todas as queries acima, incluindo sugestões de JOINs, subqueries, agregações e indexação para performance.
































































