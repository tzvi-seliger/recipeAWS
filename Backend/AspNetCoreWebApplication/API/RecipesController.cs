using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Http;
using System.Text;
using System.Web.Mvc;
using AspNetCoreWebApplication.DAO;

namespace AspNetCoreWebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public List<Ingredient> Get()
        {
            string connString = @"Data Source=DESKTOP-B54NHFS; Initial Catalog=RecipeManager; Integrated Security=SSPI;";
           
            using (SqlConnection conn = new SqlConnection(connString))
            {
                    conn.Open();
            }
            return new IngredientsDAO().getIngredients();
        }


        [HttpPost]
        public bool Post(FullRecipe fullRecipe)
        {
            string connString = @"Data Source=DESKTOP-B54NHFS; Initial Catalog=RecipeManager; Integrated Security=SSPI;";
            /*            {ingredient.IngredientName.Substring(0, 1).ToUpper()}{ingredient.IngredientName.Substring(1).ToLower()}
            */
            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                conn.Open();
                {
                    string insertRecipeQuery = $"insert into Recipes(RecipeName) values ('{fullRecipe.recipe.RecipeName}')";
                    SqlCommand command = new SqlCommand(insertRecipeQuery, conn);
                    command.ExecuteNonQuery();
                }

                foreach (RecipeToIngredient recipeToIngredient in fullRecipe.recipeList)
                {
                    string insertIngredientQuery = $"insert into ingredients(IngredientName) values ('{recipeToIngredient.IngredientName}')";
                    string insertRecipeComponent = $"insert into recipeComponents(RecipeId, IngredientId, Quantity, Unit) values ({recipeToIngredient.RecipeId},{recipeToIngredient.IngredientId}  ,{recipeToIngredient.Quantity}, '{recipeToIngredient.Unit}')";

                    SqlCommand command = new SqlCommand(insertIngredientQuery, conn);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(insertRecipeComponent, conn);
                    command.ExecuteNonQuery();
                }

                foreach (Instruction instruction in fullRecipe.instructionList)
                {
                    string insertIstructionQuery = $"insert into instructions(recipeid, instructionContent) values ({instruction.RecipeId},'{instruction.InstructionContent}')";
                    SqlCommand command = new SqlCommand(insertIstructionQuery, conn);
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}