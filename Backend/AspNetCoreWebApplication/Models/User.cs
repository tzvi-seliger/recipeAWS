using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Models
{
    public class User
    {
/*        public int UserId { get; set; }
*/        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Photo { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }

    }
}
