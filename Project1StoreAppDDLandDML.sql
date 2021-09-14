CREATE DATABASE StoreAppDB;

CREATE TABLE Stores(
	StoreID INT PRIMARY KEY IDENTITY,
	StoreLocation varchar(50) UNIQUE NOT NULL
);

CREATE TABLE Products(
  ProductID INT PRIMARY KEY IDENTITY,
  ProductName varchar(50) NOT NULL,
  ProductPrice decimal(6,2) NOT NULL
);

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	CustomerFirstName varchar(50) NOT NULL,
	CustomerLastName varchar(50) NOT NULL,
	CustomerUsername varchar(25) UNIQUE NOT NULL,
	CustomerPassword varchar(25) NOT NULL
);

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY NOT NULL,
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID) ON DELETE CASCADE,
	StoreID INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreID) ON DELETE CASCADE,
	OrderDate DATE NOT NULL,
	TotalPrice decimal(6,2) NOT NULL
);

CREATE TABLE StoreInventorys(
	StoreInventoryID INT PRIMARY KEY IDENTITY NOT NULL,
	StoreID INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreID) ON DELETE CASCADE,
	ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
	Quantity INT NOT NULL
);

CREATE TABLE OrderProducts(
	OrderProductID INT PRIMARY KEY IDENTITY NOT NULL,
	OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID) ON DELETE CASCADE,
	ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
	Quantity INT NOT NULL
);

INSERT INTO Stores(StoreLocation)
VALUES ('Houston'),('Dallas'),('Austin');
SELECT * FROM Stores;

INSERT INTO Products(ProductName, ProductPrice)
VALUES ('Hat',12.00),('Shoes',23.00),('Shirt',53.00),('Backpack',43.00);
SELECT * FROM Products;

INSERT INTO Customers(CustomerFirstName,CustomerLastName,CustomerUsername,CustomerPassword)
VALUES ('Ash','Ketchup','PikachuGuy','Pokemon12345'),('Hairy','Potter','MagicMan','Wizard12345'),('Toe-B','Keith','GuitarHero','Country12345');
SELECT * FROM Customers;

INSERT INTO Orders(CustomerID,StoreID,OrderDate,TotalPrice)
VALUES (3,1,GETDATE(),36.00),(2,1,GETDATE(),131.00),(2,3,GETDATE(),58.00);
SELECT * FROM Orders;

INSERT INTO StoreInventorys(StoreID,ProductID,Quantity)
VALUES (1,1,20),(1,2,20),(1,3,20),(1,4,20),(2,1,30),(2,2,0),(2,3,20),(2,4,0),(3,1,23),(3,2,42),(3,3,5),(3,4,7);
SELECT * FROM StoreInventorys;

INSERT INTO OrderProducts(OrderID,ProductID,Quantity)
VALUES (1,1,3),(2,1,1),(2,2,1),(2,3,1),(2,4,1),(3,1,1),(3,2,2);
SELECT * FROM OrderProducts;

SELECT * FROM Stores;
SELECT * FROM Products;
SELECT * FROM Customers;
SELECT * FROM Orders;
SELECT * FROM StoreInventorys;
SELECT * FROM OrderProducts;

--Select all orders for Houston Store
SELECT OrderID
FROM Orders
INNER JOIN Stores ON Orders.StoreID = Stores.StoreID
WHERE Stores.StoreLocation = 'Houston';

--Select all orders for Toe-B Keith
SELECT OrderID
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID
WHERE Customers.CustomerFirstName = 'Toe-B' and CustomerLastName = 'Keith';


--Select all products sold in Dallas
SELECT ProductName, StoreInventorys.Quantity
FROM Products
INNER JOIN StoreInventorys ON Products.ProductID = StoreInventorys.ProductID
INNER JOIN Stores ON StoreInventorys.StoreID = Stores.StoreID
WHERE Stores.StoreLocation = 'Dallas' and StoreInventorys.Quantity > 0;

--Select all products sold for the second order
SELECT ProductName, OrderProducts.Quantity
FROM Orders
INNER JOIN OrderProducts ON Orders.OrderID = OrderProducts.OrderID
INNER JOIN Products ON OrderProducts.ProductID = Products.ProductID
WHERE Orders.OrderID = 3;

--Things we need for MVP
--Select all customers
--Select all store locations
--Select all available products for a certain store
--Insert into Orders for the new Order created
--Insert into OrderProducts for the items purchased
--Alter the quantity of available products for a certain store upon doing the above lines
--See all past orders from a selected store location