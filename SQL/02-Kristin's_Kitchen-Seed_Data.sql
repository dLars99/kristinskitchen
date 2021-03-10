USE [KristinsKitchen];
GO

set identity_insert [Category] on
insert into Category (Id, CategoryName) values (1, 'Produce');
insert into Category (Id, CategoryName) values (2, 'Condiments');
insert into Category (Id, CategoryName) values (3, 'Oils');
insert into Category (Id, CategoryName) values (4, 'Baking goods');
insert into Category (Id, CategoryName) values (5, 'Canned');
insert into Category (Id, CategoryName) values (6, 'Dairy');
insert into Category (Id, CategoryName) values (7, 'Meats');
insert into Category (Id, CategoryName) values (8, 'Spices');
insert into Category (Id, CategoryName) values (9, 'Grains');
insert into Category (Id, CategoryName) values (10, 'Beverages');
set identity_insert [Category] off

set identity_insert [Location] on
insert into Location (Id, LocationName) values (1, 'Pantry');
insert into Location (Id, LocationName) values (2, 'Refrigerator');
insert into Location (Id, LocationName) values (3, 'Freezer');
set identity_insert [Location] off

set identity_insert [IngredientsDB] on
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (1, 'Lemongrass', null, null, 1, 1, 'bunch', null, 2, 14, 180, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (2, 'Shrimp paste', 'Barrio Fiesta', null, 2, 250, 'g', 'jar', 120, 120, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (3, 'Worcestershire sauce', 'Lea & Perrin''s', null, 2, 5, 'oz', 'bottle', 1000, 1000, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (4, 'Coconut oil', 'Publix', null, 3, 56, 'oz', 'jar', 730, 730, 730, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (5, 'Brown sugar', 'Domino', 'dark', 4, 16, 'oz', 'box', 730, 730, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (6, 'Granulated sugar', 'Domino', null, 4, 4, 'lb', 'bag', 730, 730, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (7, 'Tomato paste', 'Cento', null, 5, 4.56, 'oz', 'tube', 1, 50, 120, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (8, 'Milk', null, null, 6, 1, 'gal', 'jug', -1, 10, 180, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (9, 'Cheese', 'Kraft', 'American slices', 6, 16, 'slice', 'package', 1, 180, 240, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (10, 'Chicken', null, 'thigh', 7, 4.5, 'lb', 'package', -1, 2, 270, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (11, 'Ground beef', null, 'Angus', 7, 1, 'lb', 'package', -1, 2, 100, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (12, 'Hot dogs', 'Hebrew National', null, 7, 6, 'unit', 'package', -1, 10, 100, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (13, 'Salt', 'Morton', null, 8, 26, 'oz', 'can', 1826, -1, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (14, 'Cumin', 'Simple Truth', 'ground', 8, 1.68, 'oz', 'jar', 1000, -1, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (15, 'Potato', null, 'russet', 1, 4, 'unit', null, 25, 100, 365, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (16, 'Tomato', null, 'Roma', 1, 3, 'unit', null, 5, 7, 90, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (17, 'Olive oil', 'Colavita', 'extra virgin', 3, 25.5, 'fl oz', 'bottle', 730, -1, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (18, 'Cilantro', null, null, 1, 1, 'bunch', null, -1, 10, 180, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (19, 'Rice', 'Three Elephants', 'jasmine', 9, 20, 'lb', 'bag', 730, -1, -1, null);
insert into IngredientsDB (Id, Description, Brand, Variety, CategoryId, Quantity, QuantityUnit, ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife, ImageLocation) values (20, 'Coffee, ground', 'Gevalia', 'Espresso roast', 10, 12, 'oz', 'bag', 150, 150, 730, null);
set identity_insert [IngredientsDB] off