USE [master]

IF db_id('KristinsKitchen') IS NULL
  CREATE DATABASE [KristinsKitchen]
GO

USE [KristinsKitchen]
GO

DROP TABLE IF EXISTS [GroceryListIngredient];
DROP TABLE IF EXISTS [GroceryList];
DROP TABLE IF EXISTS [MealRecipe];
DROP TABLE IF EXISTS [Meal];
DROP TABLE IF EXISTS [RecipeInstructions];
DROP TABLE IF EXISTS [RecipeIngredient];
DROP TABLE IF EXISTS [Recipe];
DROP TABLE IF EXISTS [Location];
DROP TABLE IF EXISTS [Ingredient];
DROP TABLE IF EXISTS [IngredientsDB];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [UserProfile];

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [userName] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [ImageLocation] nvarchar(255),
  [FirebaseId] nvarchar(28) NOT NULL,

  CONSTRAINT UQ_FirebaseId UNIQUE(FirebaseId)
)
GO

CREATE TABLE [Category] (
  [Id] integer PRIMARY KEY IDENTITY,
  [CategoryName] nvarchar(255)
)
GO

CREATE TABLE [IngredientsDB] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Description] nvarchar(255) NOT NULL,
  [Brand] nvarchar(255),
  [Variety] nvarchar(255),
  [CategoryId] integer NOT NULL,
  [Quantity] integer NOT NULL,
  [QuantityUnit] nvarchar(20) NOT NULL,
  [ContainerType] nvarchar(255),
  [PantryShelfLife] integer NOT NULL,
  [FridgeShelfLife] integer NOT NULL,
  [FreezerShelfLife] integer NOT NULL,
  [ImageLocation] nvarchar(255),

  CONSTRAINT [FK_IngredientsDB_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
)
GO

CREATE TABLE [Ingredient] (
  [Id] integer PRIMARY KEY IDENTITY,
  [IngredientsDBId] integer NOT NULL,
  [OwnQuantity] integer NOT NULL,
  [OwnQuantityUnit] nvarchar(255),
  [PurchaseDate] datetime NOT NULL,
  [ExpirationDate] datetime NOT NULL,
  [LocationId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_Ingredient_IngredientsDB] FOREIGN KEY ([IngredientsDBId]) REFERENCES [IngredientsDB] ([Id]),
  CONSTRAINT [FK_Ingredient_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)
GO

CREATE TABLE [Location] (
  [Id] integer PRIMARY KEY IDENTITY,
  [LocationName] nvarchar(12)
)
GO

CREATE TABLE [RecipeIngredient] (
  [Id] integer PRIMARY KEY IDENTITY,
  [IngredientsDbId] integer NOT NULL,
  [RecipeId] integer NOT NULL,
  [Quantity] integer NOT NULL,
  [QuantityUnit] nvarchar(255) NOT NULL,
  [Substitutions] nvarchar(255),
  [Notes] nvarchar(max),
  [Optional] bit NOT NULL,

  CONSTRAINT [FK_RecipeIngredient_IngredientsDB] FOREIGN KEY ([IngredientsDBId]) REFERENCES [IngredientsDB] ([Id])
)
GO

CREATE TABLE [Recipe] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Description] nvarchar(255) NOT NULL,
  [ImageLocation] nvarchar(255),
  [Notes] nvarchar(255),
  [PrepTime] integer NOT NULL,
  [CookTime] integer NOT NULL,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_Recipe_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]),
)
GO

CREATE TABLE [RecipeInstructions] (
  [Id] integer PRIMARY KEY IDENTITY,
  [RecipeId] integer NOT NULL,
  [Instruction] nvarchar(max),
  [Sequence] integer NOT NULL,

  CONSTRAINT [FK_RecipeInstructions_Recipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe] ([Id]),
)
GO

CREATE TABLE [Meal] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Day] datetime NOT NULL,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_Meal_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]),
)
GO

CREATE TABLE [MealRecipe] (
  [Id] integer PRIMARY KEY IDENTITY,
  [MealId] integer NOT NULL,
  [RecipeId] integer NOT NULL,

  CONSTRAINT [FK_MealRecipe_Meal] FOREIGN KEY ([MealId]) REFERENCES [Meal] ([Id]),
  CONSTRAINT [FK_MealRecipe_Recipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe] ([Id]),
)
GO

CREATE TABLE [GroceryList] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Day] datetime,
  [Complete] bit NOT NULL,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_GroceryList_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]),
)
GO

CREATE TABLE [GroceryListIngredient] (
  [Id] integer PRIMARY KEY IDENTITY,
  [IngredientsDBId] integer NOT NULL,
  [GroceryListId] integer NOT NULL,
  [Purchased] bit,
  [Quantity] integer,
  [QuantityUnit] nvarchar(255),

  CONSTRAINT [FK_GroceryListIngredient_IngredientsDB] FOREIGN KEY ([IngredientsDBId]) REFERENCES [IngredientsDB] ([Id]),
)
GO