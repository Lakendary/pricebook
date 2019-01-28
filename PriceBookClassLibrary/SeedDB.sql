-- SEED DB
-- Store
INSERT INTO Store (Name, Location)
VALUES ('Checkers', 'Maerua Mall');

INSERT INTO Store (Name, Location)
VALUES ('Woermann & Brock', 'Eros');

-- Category
INSERT INTO Category (MainCategory, Name)
VALUES ('', 'Food');

INSERT INTO Category (MainCategory, Name)
VALUES ('Food', 'Vegetables');

INSERT INTO Category (MainCategory, Name)
VALUES ('Food', 'Fruit & Nuts');

INSERT INTO Category (MainCategory, Name)
VALUES ('', 'Drinks');

INSERT INTO Category (MainCategory, Name)
VALUES ('Drinks', 'Cold Beverages');

INSERT INTO Category (MainCategory, Name)
VALUES ('Drinks', 'Hot Beverages');

-- Product Link
INSERT INTO ProductLink
(Name, UoM, Weighted, MeasurementRate, CategoryId)
VALUES ('Cold Drinks', 'ml', 'Pre-Packaged', 100, 5);

INSERT INTO ProductLink
(Name, UoM, Weighted, MeasurementRate, CategoryId)
VALUES ('Instant Coffee', 'g', 'Pre-Packaged', 100, 6);

INSERT INTO ProductLink
(Name, UoM, Weighted, MeasurementRate, CategoryId)
VALUES ('Tomato Bag', 'g', 'Pre-Packaged', 100, 2);

INSERT INTO ProductLink
(Name, UoM, Weighted, MeasurementRate, CategoryId)
VALUES ('Tomatoes Loose', 'g', 'Weighted', 100, 2);

INSERT INTO ProductLink
(Name, UoM, Weighted, MeasurementRate, CategoryId)
VALUES ('Lettuce', 'ea', 'Pre-Packaged', 100, 2);

--Product
INSERT INTO Product
(Description, BrandName, PackSize, ProductLinkId)
VALUES ('Regular Cold Drink', 'Coca-Cola', 300, 1);

INSERT INTO Product
(Description, BrandName, PackSize, ProductLinkId)
VALUES ('Light Cold Drink', 'Coca-Cola', 300, 1);

INSERT INTO Product
(Description, BrandName, PackSize, ProductLinkId)
VALUES ('Medium Tomatoes', 'Freshmark', 1000, 3);

INSERT INTO Product
(Description, BrandName, PackSize, ProductLinkId)
VALUES ('Medium Tomatoes', 'Checkers', 1, 4);

INSERT INTO Product
(Description, BrandName, PackSize, ProductLinkId)
VALUES ('Crisp Lettuce', 'Checkers', 1, 5);

--Barcode
INSERT INTO Barcode
(Barcode, ProductId)
VALUES ('123', 1);

INSERT INTO Barcode
(Barcode, ProductId)
VALUES ('124', 2);

INSERT INTO Barcode
(Barcode, ProductId)
VALUES ('125', 1);

--Invoice
INSERT INTO Invoice
(Date, InvoiceAmount, InvoiceNumber, Saved, StoreId)
VALUES ('2018-10-25', 17.98, '123456', 'Open', 1);

INSERT INTO Invoice
(Date, InvoiceAmount, InvoiceNumber, Saved, StoreId)
VALUES ('2018-11-03', 21.97, '123458', 'Open', 2);

--Invoice Product
INSERT INTO InvoiceProduct
(InvoiceId, ProductId, Quantity, Sale, TotalPrice, Weight)
VALUES (1, 1, 2, 'Regular', 17.98, 0);

INSERT INTO InvoiceProduct
(InvoiceId, ProductId, Quantity, Sale, TotalPrice, Weight)
VALUES (2, 4, 1, 'Sale', 6.97, 505);

INSERT INTO InvoiceProduct
(InvoiceId, ProductId, Quantity, Sale, TotalPrice, Weight)
VALUES (2, 5, 1, 'Sale', 15.00, 0);