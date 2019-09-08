using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string IngredientName { get; set; }
        public string IngredientQuantity { get; set; }
        public string UnitType { get; set; }

    }
}
