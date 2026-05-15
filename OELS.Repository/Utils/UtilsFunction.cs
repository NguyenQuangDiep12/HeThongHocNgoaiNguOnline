using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.Utils
{
    public static class UtilsFunction
    {
        private static readonly string[] Animals =
        {
            "Lion", "Tiger", "Elephant", "Bear",
            "Deer", "Monkey", "Giraffe",
            "Kangaroo", "Wolf", "Camel"
        };

        public static string GenerateDefaultName()
        {
            var random = new Random();

            var animal = Animals[random.Next(Animals.Length)];

            int number = RandomNumberGenerator.GetInt32(100, 999);

            return $"{animal} {number}"; // Tiger + Random 100 -> 999
        }
    }
}
