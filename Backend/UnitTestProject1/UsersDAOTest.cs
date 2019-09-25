using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreWebApplication.DAO;
using AspNetCoreWebApplication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UsersDAOTest
    {
        [TestMethod]
        public void GetUsers()
        {
            UsersDAO usersdao = new UsersDAO();

            usersdao.InsertUser(new User
            {
                FirstName = "Tzvi",
                LastName = "seliger",
                EmailAddress = "tzviseliger@gmail.com",
                Photo = "photo1",
                UserLogin = "fatso212",
                Password = "whatthe7"
            });

            List<User> users = new UsersDAO().GetUsers();
            Assert.AreEqual(1, users.Count, $"users length is {users.Count} not 1");
        }
    }
}
