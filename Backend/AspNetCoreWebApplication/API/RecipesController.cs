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
using AspNetCoreWebApplication.Services;

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
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                {
                    SqlCommand command = new SqlCommand(queries.insertRecipeQuery(fullRecipe),conn);
                    command.ExecuteNonQuery();
                }
                foreach (RecipeToIngredient recipeToIngredient in fullRecipe.recipeList)
                {
                    //TODO only insert if ingredient name is not in db
                    SqlCommand command = new SqlCommand(queries.insertIngredientQuery(recipeToIngredient), conn);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(queries.insertRecipeComponent(fullRecipe, recipeToIngredient), conn);
                    command.ExecuteNonQuery();
                }
                foreach (Instruction instruction in fullRecipe.instructionList)
                { 
                    SqlCommand command = new SqlCommand(queries.insertIstructionQuery(instruction, fullRecipe), conn);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}