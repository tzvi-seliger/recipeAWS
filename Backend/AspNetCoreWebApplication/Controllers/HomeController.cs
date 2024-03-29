﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string connString;
            connString =
                @"Data Source=database-1.cur7afppexfe.us-east-2.rds.amazonaws.com,1433; Initial Catalog=RecipeManager;User ID=admin;Password=Whatthe770!";
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection conn =
                   new SqlConnection(connString))
            {
                SqlCommand command =
                    new SqlCommand("select * from recipes", conn);
                conn.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    recipes.Add(new Recipe
                    {
                        RecipeId = Convert.ToInt32(reader["RecipeId"]),
                        RecipeName = Convert.ToString(reader["RecipeName"])

                    }
                    );

                }
            }
            ViewData["Message"] = "You just created a ASP.Net Core web application!";
            return View();
        }

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }
    }
}
