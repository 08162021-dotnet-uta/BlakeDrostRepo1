CREATE DATABASE Demo_08162021batch;

CREATE TABLE Products(
  ProductId INT PRIMARY KEY IDENTITY,
  ProductName varchar(50) NOT NULL,
  ProductDescription varchar(100), NOT NULL,
  ProductPrice decimal(19,4) NOT NULL
);

CREATE TABLE Customer(
  CustomerId INT PRIMARY KEY IDENTITY,
  FirstName varchar(50),
  LastName varchar(50)
);

CREATE TABLE ItemizedOrder(
  ItemizedId uniqueidentifier NOT NULL DEFAULT newid(),
  OrderID uniqueidentifier NOT NULL DEFAULT newid(),
  CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerId) ON DELETE CASCADE,
  ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
  OrderDate date NOT NULL,
  totalAmount decimal(19,4) NOT NULL
);

INSERT INTO Products(ProductName, ProductDescription, ProductPrice)
VALUES ('Backpack', 'Can hold stuff for you.', 65.99),
('Ice Chest', 'Stable temperature container.', 139.99),
('Gloves', 'Hand socks.', 25.99),
('Coozie', 'Keeps your drink cold but your hands not.', 4.99);

INSERT INTO Customer(FirstName, LastName)
VALUES ('Blake', 'Drost');

SELECT * FROM Products;

SELECT * FROM Customer;