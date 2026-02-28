-- Cria o banco de dados usado neste exemplo
CREATE DATABASE InventoryDB;

-- Seleciona o banco de dados recém-criado para execução das próximas instruções
USE InventoryDB;

-- Cria a tabela `Products` com colunas básicas e chave primária auto-incremental
CREATE TABLE Products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(255) NOT NULL,
    Category VARCHAR(100),
    Price DECIMAL(10, 2),
    Stock INT
);

-- Insere alguns registros de exemplo na tabela
INSERT INTO Products (ProductName, Category, Price, Stock) VALUES
('Laptop', 'Electronics', 999.99, 50),
('Smartphone', 'Electronics', 499.99, 200),
('Headphones', 'Electronics', 199.99, 150),
('Coffee Maker', 'Home Appliances', 79.99, 100),
('Blender', 'Home Appliances', 59.99, 80);

-- Ativa o profiling de consultas (útil para medir tempo de execução das queries)
SET PROFILING = 1;

-- Tenta adicionar uma chave primária na coluna `ProductID`
-- Nota: `ProductID` já foi definido como PRIMARY KEY no CREATE TABLE acima;
-- esta instrução é redundante e pode falhar dependendo do SGBD.
ALTER TABLE Products ADD PRIMARY KEY (ProductID);

-- Executa uma consulta que filtra por categoria (sem índice ainda)
SELECT * FROM Products WHERE Category = 'Electronics';

-- Mostra os perfis de execução acumulados quando `SET PROFILING = 1` está ativo
SHOW PROFILES;

-- Exibe o plano de execução da consulta anterior (ajuda a entender uso de índices)
EXPLAIN SELECT * FROM Products WHERE Category = 'Electronics';

-- Cria um índice simples na coluna `Category` para melhorar buscas por categoria
CREATE INDEX idx_category ON Products(Category);

-- Repete a mesma consulta para comparar desempenho após a criação do índice
SELECT * FROM Products WHERE Category = 'Electronics';

-- Mostra novamente os perfis de execução para comparação
SHOW PROFILES;

-- Verifica o plano de execução agora com o índice criado
EXPLAIN SELECT * FROM Products WHERE Category = 'Electronics';

-- Remove o índice `idx_category` criado anteriormente
DROP INDEX idx_category ON Products;

-- Cria um índice composto em (`Category`, `Price`) para consultas que filtram por ambas
CREATE INDEX idx_category_price ON Products(Category, Price);

-- Consulta que filtra por categoria e preço (beneficia-se do índice composto)
SELECT * FROM Products WHERE Category = 'Electronics' AND Price < 500;

-- Exibe o plano de execução para a consulta composta (útil para ver se o índice é usado)
EXPLAIN SELECT * FROM Products WHERE Category = 'Electronics' AND Price < 500;

-- Mostra perfis finais das queries executadas
SHOW PROFILES;


