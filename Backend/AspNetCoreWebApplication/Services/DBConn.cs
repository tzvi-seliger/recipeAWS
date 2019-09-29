using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Services
{
    public class DBConn : IDBConn
    {
        public string getConnString()
        {
            return @"Data Source=database-1.cur7afppexfe.us-east-2.rds.amazonaws.com,1433; Initial Catalog=RecipeManager;User ID=admin;Password=Whatthe770!";
        }
        public string getDevString()
        {
            return @"Data Source=DESKTOP-B54NHFS; Initial Catalog=RecipeManager; Integrated Security=SSPI;";
        }


        public string getQuery(string query)
        {
            return query;
        }
    }
}
