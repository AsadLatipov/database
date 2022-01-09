using System;
using NajotTalimOshxona.Consists;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using NajotTalimOshxona.Moduls;
using System.IO;
using Newtonsoft.Json;

namespace NajotTalimOshxona.Extensions
{
    internal class MyExtensionsPack
    {

        public static string HidePass()
        {
            var password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return password;
        }

        public static bool HashCode(string code)
        {
            bool dasa = true;

            byte[] tmpSource2;
            byte[] tmpHash2;

            tmpSource2 = ASCIIEncoding.ASCII.GetBytes(code);
            tmpHash2 = new MD5CryptoServiceProvider().ComputeHash(tmpSource2);

            for (int i = 0; i < tmpHash2.Length; i++)
            {
                if (tmpHash2[i] != Paths.Password[i])
                {
                    dasa = false;
                    break;
                }
            }
            return dasa;
        }

        
    }
}