using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Services
{
    public static class RandomMethods
    {
        public static string ToTitle(string str)
        {
            return String.Join(' ', str.Split(' ').Select(x => $"{x.Substring(0, 1).ToUpper()}{x.Substring(1).ToLower()}"));
        }
    }
}
