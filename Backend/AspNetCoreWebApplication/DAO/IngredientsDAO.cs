using AspNetCoreWebApplication.Models;
using AspNetCoreWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.DAO
{
    public class IngredientsDAO
    {
        public List<Ingredient> getIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string connString = @"Data Source=database-1.cur7afppexfe.us-east-2.rds.amazonaws.com,1433; Initial Catalog=RecipeManager;User ID=admin;Password=Whatthe770!";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand select = new SqlCommand("select * from Ingredients", conn);

                conn.Open();

                SqlDataReader reader = select.ExecuteReader();

                while (reader.Read())
                {
                    ingredients.Add(
                        new Ingredient
                        {
                            IngredientId = Convert.ToInt32(reader["IngredientId"]),
                            IngredientName = Convert.ToString(reader["IngredientName"]),
                        }
                   );
                }
            }
            return ingredients;
        }
        public bool submitIngredient(Ingredient ingredient)
        {

            string connString = @"Data Source=database-1.cur7afppexfe.us-east-2.rds.amazonaws.com,1433; Initial Catalog=RecipeManager;User ID=admin;Password=Whatthe770!";
/*            {ingredient.IngredientName.Substring(0, 1).ToUpper()}{ingredient.IngredientName.Substring(1).ToLower()}
*/            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand($"insert into Ingredients(IngredientName) VALUES ('{RandomMethods.ToTitle(ingredient.IngredientName)}')", conn);

                conn.Open();
                foreach (Ingredient ing in getIngredients())
                {
                    if (ing.IngredientName.ToLower().Equals(ingredient.IngredientName.ToLower()))
                    {
                        return false;
                    }

                }
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}
