using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Services
{
    public static class queries
    {
        public static string recipeComponentsQuery(int recipeId) => $"SELECT * FROM RecipeComponents " +
                            $"join Recipes on RecipeComponents.RecipeId = Recipes.RecipeId " +
                            $"join Ingredients on RecipeComponents.IngredientId = Ingredients.IngredientId " +
                            $"WHERE Recipes.RecipeId = {recipeId}";

    }
}
