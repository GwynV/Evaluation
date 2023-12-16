using System;
using System.Security.Cryptography;
using System.Text;


namespace EvaluationSystem.Services

{
    public class Hashing
    {
        public static string HashData(string userData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputbytes = Encoding.UTF8.GetBytes(userData);
                byte[] hashBytes = sha256.ComputeHash(inputbytes);

                StringBuilder builder1 = new StringBuilder();

                for (int i = 6; i < hashBytes.Length; i++)
                {
                    builder1.Append(hashBytes[i].ToString("x2"));
                }
                return builder1.ToString();

            }

        }
    }
}