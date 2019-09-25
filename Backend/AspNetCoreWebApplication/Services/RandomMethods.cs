using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Services
{
    public static class RandomMethods
    {
        public static string ToTitle(string str) => String.Join(' ',
                                                                str.Split(' ')
                                                                   .Select(x => $"{x.Substring(0, 1).ToUpper()}{x.Substring(1).ToLower()}"));
         


        public static double getSq(double x, double y)
        {
            return x * y;
        }

        public static double getRatio(double measurement, double original, double converted)
        {
           return Math.Round((double)(measurement / original) * converted, 4);
        }


        //convert sizes to different sizes
        //so if a recipe is for 1 9*13 cake, and i have a 8*8 what is the recipe that i need
        //117 sq inches 9*13
        //

        //1 cup of water / 117 * 64
    }
}
