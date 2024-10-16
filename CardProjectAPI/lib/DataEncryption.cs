using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectAPI.lib
{
    public static class DataEncryption
    {
        public static string Encrypt(string Input)
        {
            char[] CharInput = Input.ToCharArray();
            string StrOut = String.Empty;
            char t;
            int p;

            for (int i = 0; i < CharInput.Length; i++)
            {
                p = (int)CharInput[i] ^ 1;
                t = Convert.ToChar(p);
                StrOut += t;
            }

            StrOut = Input;

            byte[] StrBytes = System.Text.Encoding.UTF8.GetBytes(StrOut);
            var HashOutStringBuilder = new StringBuilder(128);


            using (SHA512 HashObject = SHA512.Create())
            {
                var HashOut = HashObject.ComputeHash(StrBytes);

                HashOutStringBuilder.AppendJoin("", HashOut.Select(x => x.ToString("X2")));
            }

            return HashOutStringBuilder.ToString();
        }

        public static string Hash(string Input)
        {
            byte[] StrBytes = System.Text.Encoding.UTF8.GetBytes(Input);
            var HashOutStringBuilder = new StringBuilder(128);

            using (SHA512 HashObject = SHA512.Create())
            {
                var HashOut = HashObject.ComputeHash(StrBytes);

                HashOutStringBuilder.AppendJoin("", HashOut.Select(x => x.ToString("X2")));
            }

            return HashOutStringBuilder.ToString();
        }
    }
}
