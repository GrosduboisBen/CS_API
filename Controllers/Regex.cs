using System;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace win1_api.Authentication {
    public class StringVerifications {
        public string StringToSha256(string entry)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] encoded = hash.ComputeHash(Encoding.UTF8.GetBytes(entry));
                StringBuilder encodedPassword = new StringBuilder();

                for (int i = 0; i < encoded.Length; i++)
                {
                    // the string should be formatted in hexa.
                    encodedPassword.Append(encoded[i].ToString("x2"));
                }
                return encodedPassword.ToString();
            }
        }

        public bool RegExEmailVerification(string entry)
        {
            Regex emailRegEx = new Regex(@".+\@.+\..");
            Match match = emailRegEx.Match(entry);
            return match.Success;
        }
    }
}