use master;
IF DB_ID('RecipeManager') IS NOT NULL
 DROP database RecipeManager

create database RecipeManager;
use RecipeManager;

--reg table
create table Recipes(
 RecipeId int identity(1,1) not null,
 RecipeName varchar(100) not null,

 CONSTRAINT PK_RecipeId PRIMARY KEY (RecipeId)
);

--reg table
create table Ingredients (
 IngredientId int identity(1,1) not null,
 IngredientName varchar(100) not null,

 CONSTRAINT PK_IngredientId PRIMARY KEY (IngredientId)

);

--many instructions can belong to each recipe 
create table Instructions(
  InstructionId int identity(1,1) not null,
  RecipeId int not null,
  InstructionContent varchar(100) not null,

  CONSTRAINT PK_InstructionId PRIMARY KEY (InstructionId),

  CONSTRAINT FK_Instructions_RecipeId FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId) 
);

--each component can belong to one recipe
--each component 
create table RecipeComponents(
RecipeComponentId int identity(1,1) not null,
RecipeId int not null,
IngredientId int not null,
Quantity int not null,
Unit varchar(20) not null,

CONSTRAINT PK_RecipeComponentId PRIMARY KEY (RecipeComponentId),

CONSTRAINT FK_RecipeComponent_RecipeId FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
CONSTRAINT FK_IngredientId FOREIGN KEY (IngredientId) REFERENCES Ingredients(IngredientId) 
);



