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
    }
}
