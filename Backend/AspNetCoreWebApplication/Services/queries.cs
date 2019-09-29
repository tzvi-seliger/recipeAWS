using AspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Services
{
    public static class queries
    {
        public static string recipeComponentsQuery(int recipeId) =>
            $"SELECT * FROM RecipeComponents " +
            $"JOIN Recipes on RecipeComponents.RecipeId = Recipes.RecipeId " +
            $"JOIN Ingredients on RecipeComponents.IngredientId = Ingredients.IngredientId " +
            $"WHERE Recipes.RecipeId = {recipeId}";

        //not being used
        public static string fullRawRecipeQuery() =>
            $"SELECT instructions.InstructionContent, recipes.RecipeName, Ingredients.IngredientName, RecipeComponents.Quantity, RecipeComponents.Unit from Recipes " +
            $"JOIN RecipeComponents on recipes.RecipeId = RecipeComponents.RecipeId" +
            $"JOIN instructions on recipes.RecipeId = Instructions.RecipeId" +
            $"JOIN ingredients on RecipeComponents.IngredientId = Ingredients.IngredientId" +
            $"WHERE recipes.RecipeId = 1";

        public static string insertRecipeComponent(FullRecipe fullRecipe, RecipeToIngredient recipeToIngredient) => $"insert into recipeComponents(" +
                       $"RecipeId, " +
                       $"IngredientId, " +
                       $"Quantity, " +
                       $"Unit) " +
                       $"values" +
                         $"((select recipeid from recipes where recipes.recipename='{fullRecipe.recipe.RecipeName}')," +
                         $"(select ingredientId from Ingredients where ingredients.ingredientName='{recipeToIngredient.IngredientName}'), " +
                         $"{recipeToIngredient.Quantity}, " +
                         $"'{recipeToIngredient.Unit}')";

        internal static string insertRecipeQuery(FullRecipe fullRecipe) => $"insert into Recipes(RecipeName) values ('{fullRecipe.recipe.RecipeName}')";

        public static string insertIngredientQuery(RecipeToIngredient recipeToIngredient) =>
            $"insert into ingredients(IngredientName) values ('{recipeToIngredient.IngredientName}')";

        public static string insertIstructionQuery(Instruction instruction, FullRecipe fullRecipe) =>
            $"insert into instructions(recipeid, instructionContent) values " +
            $"((select recipes.recipeId from recipes where recipes.recipeName = '{fullRecipe.recipe.RecipeName}')," +
            $"'{instruction.InstructionContent}')";

        //insertRecipeQuery
        //insertIngredientQuery
        //insertRecipeComponent
        //insertInstructionQuery


        internal static string updateRecipeQuery(FullRecipe fullRecipe)
        {
            return $"update Recipes set RecipeName = {fullRecipe.recipe.RecipeName} where Recipes.RecipeId = {fullRecipe.recipe.RecipeId};";
        }

        /*        internal static string updateIngredientQuery(RecipeToIngredient recipeToIngredient)
                {
                    return $"update ingredients set IngredientName values ('{recipeToIngredient.IngredientName}')";
                }*/

        internal static string updateRecipeComponent(FullRecipe fullRecipe, RecipeToIngredient recipeToIngredient)
        {
            return $"update recipeComponents (" +
                       $" set RecipeId = (select recipeid from recipes where recipes.recipename='{fullRecipe.recipe.RecipeName}'), " +
                       $" set IngredientId = (select ingredientId from Ingredients where ingredients.ingredientName='{recipeToIngredient.IngredientName}'), " +
                       $" set Quantity = {recipeToIngredient.Quantity}" +
                       $" set Unit = '{recipeToIngredient.Unit}') ) " +
                       $" where recipes.recipeId = {fullRecipe.recipe.RecipeId};";
        }

        internal static string updateIstructionQuery(Instruction instruction, FullRecipe fullRecipe) =>
                $"update instructions " +
                $"set instructionContent = '{instruction.InstructionContent}' " +
                $" where instructions.instructionId = {instruction.InstructionId};";
    }
}
