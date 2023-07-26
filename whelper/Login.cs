using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace whelper
{
    public class Session
    {
        
    }
    class Security {
        protected static string a = "abusivejew";
        protected static internal class Derivation {
            static byte[] SaltSize = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //private static byte[] a = "253123A643F3C3902FF882A9F6987A1487E127DD60B2C4474DD0536D7243CF3238449955AE8B457CC63E70CD6E6F423D49159593A2F47EB65ADE35C706C22016";
            /*public string A(string rawData) {
                string result = "";
                    using (RijndaelManaged c = new RijndaelManaged()) {
                        c.KeySize = 256;
                        c.BlockSize = 128;
                    var k = new Rfc2898DeriveBytes();
                    }
               
            }*/
            static bool IsValidBase64(string rawData) {
                rawData = rawData.Trim();
                return (rawData.Length % 4 == 0) && Regex.IsMatch(rawData, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
            }
        }
    }
}
