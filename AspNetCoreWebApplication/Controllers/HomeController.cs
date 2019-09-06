using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string connString;
            string response = "";

            connString =
                @"Data Source=database-1.cur7afppexfe.us-east-2.rds.amazonaws.com;" +
                 "Initial Catalog=Recipes;" +
                 "User ID=admin;" +
                 "Password=Whatthe770!";
            response = "Connection Made";

            using (SqlConnection conn =
                   new SqlConnection(connString))
            {
                SqlCommand command =
                    new SqlCommand("select * from recipes", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    response += Convert.ToString(reader["IngredientName"]);
                    response += Convert.ToString(reader["IngredientQuantity"]);
                    response += Convert.ToString(reader["UnitType"]);
                }
            }

            ViewData["Message"] = response;
            return View();
        }

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }
    }
}
