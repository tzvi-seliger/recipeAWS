use RecipeManager;

insert into Recipes(RecipeName) VALUES 
	('Blueberry Muffin'),
	('ChocolateChip Cookies'),
	('Classic Pancakes'),
	('Tiramisu')
insert into Ingredients(IngredientName) VALUES 
	('All Purpose Flour'),
	('Eggs'),
	('Vanilla Extract'),
	('Whole Milk')
insert into Instructions(RecipeId, InstructionContent)
SELECT Recipes.RecipeId, 'This is my First Instruction'
FROM Recipes Where RecipeName = 'Blueberry Muffin'
insert into Instructions(RecipeId, InstructionContent)
SELECT Recipes.RecipeId, 'This is my Second Instruction'
FROM Recipes Where RecipeName = 'Blueberry Muffin'
insert into Instructions(RecipeId, InstructionContent)
SELECT Recipes.RecipeId, 'This is my First Instruction'
FROM Recipes Where RecipeName = 'ChocolateChip Cookies'
insert into Instructions(RecipeId, InstructionContent)
SELECT Recipes.RecipeId, 'This is my Second Instruction'
FROM Recipes Where RecipeName = 'ChocolateChip Cookies'

Insert into RecipeComponents(RecipeId, IngredientId, Quantity, Unit)
	VALUES (1, 1, 1, 'Cups'),
		   (1, 2, 2, 'Cups'),
		   (1, 1, 1, 'Cups'),
		   (1, 2, 2, 'Cups');
