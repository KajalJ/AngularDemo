CREATE TABLE Product(
	ID int,
	Name nvarchar(150),
	Price smallmoney, 
	[Description] nvarchar(2000),
	CanPurchase bit,
	SoldOut bit
	)

CREATE TABLE Image(
	ProductID int,
	[Full] nvarchar(256),
	Thumb nvarchar(256)
)

CREATE TABLE Review(
	ID int,
	ProductID int,
	Stars int,
	Body ntext,
	Author nvarchar(500)
)



INSERT INTO Product(ID, Name, Price, [Description], CanPurchase, SoldOut)
VALUES(1, 'Dodecahedron', 2.95, 
'Some gems have qualities beyond their lustre, beyond their shine.  Dodecahedron is one of those gems.', 1, 0)

INSERT INTO Product(ID, Name, Price, [Description], CanPurchase, SoldOut)
VALUES(2, 'Pentagonal', 5.95, 'I am a gem shaped as a pentagon', 1, 0)

INSERT INTO Image(ProductID, [Full], Thumb)
VALUES(1, 'dodecahedron.png', 'dodecahedron_thumb.png')

INSERT INTO Image(ProductID, [Full], Thumb)
VALUES(1, 'dodecahedron2.jpg', 'dodecahedron2_thumb.jpg')

INSERT INTO Review(ID, ProductID, Stars, Body, Author)
VALUES(1, 1, 5, 'I love this product', 'joe@thomas.com')

INSERT INTO Review(ID, ProductID, Stars, Body, Author)
VALUES(2, 1, 1, 'This product isn''t even real', 'tim@hater.com')

