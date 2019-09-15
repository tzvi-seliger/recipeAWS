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
            return View();
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
            
                UsersList.users.Add(
                new User {
/*                    UserId = new UsersDAO().users.Count + 1,
*/                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress,
                    Photo = user.Photo,
                    UserLogin = user.UserLogin,
                    Password = user.Password
                }

           );

            return RedirectToAction("RegisterForm");
        }
    }
}