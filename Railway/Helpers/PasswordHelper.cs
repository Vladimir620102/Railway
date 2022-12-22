using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Railway.Helpers
{
    internal class PasswordHelper
    {
        public static string Sha1EncryptPassword(string text)
        {
            var buffer = new UTF8Encoding().GetBytes(text);
            var hash = BitConverter.ToString(
                new SHA1CryptoServiceProvider().ComputeHash(buffer)).Replace("-", "");
            return hash;
        }
    }
}
