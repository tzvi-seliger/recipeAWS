SELECT * FROM recipes;

--Display all instructions with corresponding Recipes
SELECT * FROM Instructions JOIN Recipes ON Instructions.RecipeId = Recipes.RecipeId

--Display all instructions with corresponding Recipe for 'Blueberry Muffin'
SELECT * FROM Instructions JOIN Recipes ON Instructions.RecipeId = Recipes.RecipeId
WHERE Recipes.RecipeName = 'Blueberry Muffin'

--Display all instructions with corresponding Recipe for 'ChocolateChip Cookies'
SELECT * FROM Instructions JOIN Recipes ON Instructions.RecipeId = Recipes.RecipeId
WHERE Recipes.RecipeName = 'ChocolateChip Cookies'