using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.DAO;
using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View(new UsersDAO().GetUsers());
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        public IActionResult RegisterForm()
        {
            return View();
        }

        public IActionResult LoginFormAction()
        {
            
            return RedirectToAction("Index");
        }
        public IActionResult RegisterFormAction(User user)
        {

            new UsersDAO().InsertUser(user); 
            return RedirectToAction("RegisterForm");
        }
    }
}