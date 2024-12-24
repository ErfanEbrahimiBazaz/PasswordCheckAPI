

using System.Text;
using System.Security.Cryptography;

namespace PasswordCheck.API.Services
{
    //public abstract class SHA1 : System.Security.Cryptography.HashAlgorithm
    //{

    //}

    // use this link to calculate sha1:  https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha1?view=net-9.0
    //public string CalculateSha1(string password)
    //{
    //    byte[] sha1 = SHA1.Create();


    //}

    //public interface IPasswordOperations
    //{
    //    public string CalculateSHA1Hash(string input);
    //}

    public static class PasswordOperations
    {


        public static string CalculateSHA1Hash(string input)
        {
            // Convert the input string to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Create a SHA1 instance
            using (SHA1 sha1 = (SHA1)SHA1.Create())
            {
                // Compute the hash
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                // Convert the hash bytes to a hexadecimal string
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }

                return hashStringBuilder.ToString().Substring(0, 5);
            }
        }

    }
}

