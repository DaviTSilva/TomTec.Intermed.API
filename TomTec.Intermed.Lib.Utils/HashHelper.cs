using System;
using System.Security.Cryptography;

namespace TomTec.Intermed.Lib.Utils
{
    static public class HashHelper
    {
        static public string GeneratePasswordSalt()
        {
            int max_length = 22;
            var salt = new byte[max_length];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return "$2a$10$" + Convert.ToBase64String(salt);
        }
    }
}
