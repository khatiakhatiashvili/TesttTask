using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace TestTask.Core.Application.Extensions
{
    public static class ExtensionFunctions
    {
        /// <summary>
        /// პაროლის დაშიფვრა
        /// </summary>
        public static string GetPasswordHash(string userName, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password));

            var computeHash = md5.ComputeHash(bytes);
            return BitConverter.ToString(computeHash).Replace("-", "");
        }
        
   
    }
}
