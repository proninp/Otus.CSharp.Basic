CREATE TABLE Customers (
    ID SERIAL PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Age INT NOT NULL CHECK (Age > 0)
);

CREATE TABLE Products (
    ID SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    StockQuantity INT NOT NULL CHECK (StockQuantity >= 0),
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0)
);

CREATE TABLE Orders (
    ID SERIAL PRIMARY KEY,
    CustomerID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    FOREIGN KEY (CustomerID) REFERENCES Customers(ID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE
);

CREATE INDEX idx_orders_customer_product ON Orders(CustomerID, ProductID);

CREATE INDEX idx_customers_Age_index ON Customers(Age) include (FirstName, LastName);
