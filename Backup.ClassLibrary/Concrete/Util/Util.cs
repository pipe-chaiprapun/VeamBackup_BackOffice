using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordUtility;
using PasswordUtility.PasswordGenerator;

namespace Backup.ClassLibrary.Concrete.Util
{
    public class Util
    {
        public static string PasswordGenerate(int length, bool useUpperCase = false, bool UseDigits = false, bool UseSpecialCharactors = false)
        {
            return PwGenerator.Generate(length, useUpperCase, UseDigits, UseSpecialCharactors).ReadString();

            //Random random = new Random();
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //return new string(Enumerable.Repeat(chars, length)
            //  .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
