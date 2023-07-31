using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency_temp.Classes
{
    // Class for password encryption using MD5 hash algorithm.
    class md5
    {
        // Method to hash the password using MD5.
        public static string hashPassword(string password)
        {
            MD5 md5 = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
            {
                sb.Append(a.ToString("X2"));
            }

            // Return the hashed password as a string in hexadecimal format.
            return sb.ToString();
        }
    }
}
