using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Models
{
    public class RecipeToIngredient
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

    }
}
