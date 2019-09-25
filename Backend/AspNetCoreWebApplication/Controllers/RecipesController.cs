using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Microsoft.Web.Helpers;
using AspNetCoreWebApplication.Interfaces;
using AspNetCoreWebApplication.Services;

namespace AspNetCoreWebApplication.Controllers
{

    public class RecipesController : Controller
    {
        private readonly IDBConn _dBConn;
        public RecipesController(IDBConn dbconn)
        {
            _dBConn = dbconn;
        }
        /*      public async Task<IActionResult> Create([Bind("BlogId,...Img")] Blog blog t, IFormFile Image)
              {
                  if (ModelState.IsValid)
                  {
                      if (Image != null)

                      {
                          if (Image.Length > 0)

                          //Convert Image to byte and save to database

                          {

                              byte[] p1 = null;
                              using (var fs1 = Image.OpenReadStream())
                              using (var ms1 = new MemoryStream())
                              {
                                  fs1.CopyTo(ms1);
                                  p1 = ms1.ToArray();
                              }
                              Blog.Img = p1;

                          }
                      }

                      _context.Add(client);
                      await _context.SaveChangesAsync();

                      return RedirectToAction("Index");
                  }*/

        public IActionResult Index()
        {
            int recipeId = 1;
            List<FullRecipe> fullrecipes = new List<FullRecipe>();
            using (SqlConnection conn = new SqlConnection(_dBConn.getConnString()))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Recipes", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<RecipeToIngredient> recipecomponents = new List<RecipeToIngredient>();
                    List<Instruction> instructions = new List<Instruction>();
                    Recipe recipe = new Recipe
                    {
                        RecipeId = Convert.ToInt32(reader["RecipeId"]),
                        RecipeName = Convert.ToString(reader["RecipeName"])
                    };
                    recipeId = recipe.RecipeId;

                    using (SqlConnection conn2 = new SqlConnection(_dBConn.getConnString()))
                    {
                        conn2.Open();
                        SqlCommand getRecipeComponents = new SqlCommand(_dBConn.getQuery(queries.recipeComponentsQuery(recipeId)), conn2);
                        SqlDataReader componentsreader = getRecipeComponents.ExecuteReader();
                        while (componentsreader.Read())
                        {
                            recipecomponents.Add(
                                new RecipeToIngredient
                                {
                                    IngredientId = Convert.ToInt32(componentsreader["IngredientId"]),
                                    RecipeId = Convert.ToInt32(componentsreader["RecipeId"]),
                                    Quantity = Convert.ToInt32(componentsreader["Quantity"]),
                                    Unit = Convert.ToString(componentsreader["Unit"]),
                                    IngredientName = Convert.ToString(componentsreader["IngredientName"])

                                }
                           );
                        }
                    }

                    using (SqlConnection conn3 = new SqlConnection(_dBConn.getConnString()))
                    {
                        conn3.Open();
                        SqlCommand getInstructions = new SqlCommand(
                            $"SELECT * FROM Instructions " +
                            $"JOIN Recipes ON Instructions.RecipeId = Recipes.RecipeId " +
                            $"WHERE Recipes.RecipeId = {recipeId}", conn3
                           );
                        SqlDataReader instructionsreader = getInstructions.ExecuteReader();
                        while (instructionsreader.Read())
                        {
                            instructions.Add(
                                new Instruction
                                {
                                    InstructionId = Convert.ToInt32(instructionsreader["InstructionId"]),
                                    InstructionContent = Convert.ToString(instructionsreader["InstructionContent"])
                                }
                           );
                        }
                    }


                    fullrecipes.Add(
                        new FullRecipe
                        {
                            recipe = recipe,
                            recipeList = recipecomponents,
                            instructionList = instructions
                        }
                    );
                }
            }
            return View(fullrecipes);
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult SubmitForm(FullRecipe fullrecipe)
        {
            //submit new recipe
            // 1) submit new recipe id, name to recipes
            // 2) where recipe id is the above submit ingredients using select list, adding quantities with form
            // 3) add instructions based on recipe id with a form 
            // submit recipe with submit form button
            foreach(RecipeToIngredient recipeToIngredient in fullrecipe.recipeList)
            {
                string insertIngredientQuery = $"insert into ingredients(IngredientName) values ('{recipeToIngredient.IngredientName}')";
            }
           
            /*string insertRecipeNameQuery = $"insert into recipes(RecipeName) values('{fullrecipe.recipe.RecipeName}')";
            string insertComponentQuery = $"insert into RecipeComponents(RecipeId, IngredientId, Quantity, Unit) VALUES" +
                $"(SELECT RecipeId from Recipes where Recipes.RecipeName = '{fullrecipe.recipe.RecipeName}')," +
                $"(SELECT IngredientId FROM Ingredients where Ingredients.IngredientName = '{fullrecipe.recipeList[0].IngredientName}'),3,'cups');";
            string insertIinstructionQuery = $"insert into instructions(RecipeId, InstructionContent) values" +
                $"(select recipes.recipeId from Recipes where Recipes.RecipeName = '{fullrecipe.recipe.RecipeName}')," +
                $"'{fullrecipe.instructionList[0].InstructionContent}')";*/
       
                return RedirectToAction("Index");
        }
        /*  public IActionResult SubmitImage()
          {

          }

          public IActionResult ImageForm()
          {
              return View();
          }*/

    }
}




