using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.DAO;
using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            return View(new IngredientsDAO().getIngredients());
        }

        public IActionResult IngredientForm()
        {
            return View();
        }

        public IActionResult IngredientFormSubmit(Ingredient ingredient)
        {
            new IngredientsDAO().submitIngredient(ingredient);
            return RedirectToAction("Index");
        }
    }
}