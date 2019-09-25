using AspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.DAO
{
    public static class UsersList
    {
        public static List<User> users = new List<User>();
    }
    public class UsersDAO
    {
        

        public List<User> GetUsers()
        {
            return UsersList.users;
        }

        public bool InsertUser(User user)
        {
            UsersList.users.Add(
                new User
                {
                    /*                    UserId = new UsersDAO().users.Count + 1,
                    */
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress,
                    Photo = user.Photo,
                    UserLogin = user.UserLogin,
                    Password = user.Password
                }

            );
            return true;
        }
    }
}

