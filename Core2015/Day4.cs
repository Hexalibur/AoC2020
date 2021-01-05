using System;
using System.Security.Cryptography;
using System.Text;

namespace Core2015
{
    public class Day4
    {
        public long GetLowestMatch(string key, string matchStart)
        {
            long keySuffix = 0;
            var hash = "";

            do
            {
                keySuffix++;
                hash = GetHash($"{key}{keySuffix}");
            } while (!hash.StartsWith(matchStart));

            return keySuffix;
        }

        public string GetHash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            return BitConverter.ToString(data).Replace("-", "");
        }
    }
}
