using AspNetCoreWebApplication.Models;
using AspNetCoreWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.API_DAO
{
    public class RecipeAPI_DAO
    {
        private readonly IDBConn _dBConn;
        public RecipeAPI_DAO(IDBConn dbconn)
        {
            _dBConn = dbconn;
        }

        public List<FullRecipe> GetAllRecipes()
        {

            int recipeId = 0;
            List<FullRecipe> fullrecipes = new List<FullRecipe>();
            using (SqlConnection conn = new SqlConnection(_dBConn.getDevString()))
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

                    using (SqlConnection conn2 = new SqlConnection(_dBConn.getDevString()))
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

                    using (SqlConnection conn3 = new SqlConnection(_dBConn.getDevString()))
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
            return fullrecipes;
        }

        internal void UpdateRecipe(FullRecipe fullRecipe)
        {
            using (SqlConnection conn = new SqlConnection(_dBConn.getDevString()))
            {
                conn.Open();
                {
                    SqlCommand command = new SqlCommand(queries.updateRecipeQuery(fullRecipe), conn);
                    command.ExecuteNonQuery();
                }
                foreach (RecipeToIngredient recipeToIngredient in fullRecipe.recipeList)
                {
                    //TODO only insert if ingredient name is not in db
                    /*                    SqlCommand command = new SqlCommand(queries.updateIngredientQuery(recipeToIngredient), conn);
                                        command.ExecuteNonQuery();*/
                    SqlCommand command = new SqlCommand(queries.updateRecipeComponent(fullRecipe, recipeToIngredient), conn);
                    command.ExecuteNonQuery();
                }
                foreach (Instruction instruction in fullRecipe.instructionList)
                {
                    SqlCommand command = new SqlCommand(queries.updateIstructionQuery(instruction, fullRecipe), conn);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void PostRecipe(FullRecipe fullRecipe)
        {
            using (SqlConnection conn = new SqlConnection(_dBConn.getDevString()))
            {
                conn.Open();
                {
                    SqlCommand command = new SqlCommand(queries.insertRecipeQuery(fullRecipe), conn);
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
        }

        //insertRecipeQuery
        //insertIngredientQuery
        //insertRecipeComponent
        //insertInstructionQuery
        public FullRecipe GetRecipe(int id)
        {
            List<RecipeToIngredient> recipecomponents = new List<RecipeToIngredient>();
            Recipe recipe = new Recipe();
            List<Instruction> instructions = new List<Instruction>();
            using (SqlConnection conn = new SqlConnection(_dBConn.getDevString()))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Recipes where recipes.RecipeId = {id}", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    recipe.RecipeId = Convert.ToInt32(reader["RecipeId"]);
                    recipe.RecipeName = Convert.ToString(reader["RecipeName"]);

                    using (SqlConnection conn2 = new SqlConnection(_dBConn.getDevString()))
                    {
                        conn2.Open();
                        SqlCommand getRecipeComponents = new SqlCommand(_dBConn.getQuery(queries.recipeComponentsQuery(id)), conn2);
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

                    using (SqlConnection conn3 = new SqlConnection(_dBConn.getDevString()))
                    {
                        conn3.Open();
                        SqlCommand getInstructions = new SqlCommand(
                            $"SELECT * FROM Instructions " +
                            $"JOIN Recipes ON Instructions.RecipeId = Recipes.RecipeId " +
                            $"WHERE Recipes.RecipeId = {id}", conn3
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
                }
                return new FullRecipe
                {
                    recipe = recipe,
                    recipeList = recipecomponents,
                    instructionList = instructions
                };
            }
        }
    }
}
