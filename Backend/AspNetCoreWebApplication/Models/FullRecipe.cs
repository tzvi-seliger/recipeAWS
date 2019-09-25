using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Models
{
    public class FullRecipe
    {
        public Recipe recipe { get; set; }
        public List<RecipeToIngredient> recipeList { get; set; }
        public List<Instruction> instructionList { get; set; }

    }
}
