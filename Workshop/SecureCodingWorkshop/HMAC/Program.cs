using System;
using System.IO;
using System.Text;

namespace SecureCodingWorkshop.Hmac
{
    static class Program
    {
        private static void Main()
        {
            // TODO : Generate a series of salts.
            // TODO : Calculate MD5, SHA1, SH256 and SHA512 based HMAC's for a series of messages.
            // TODO : Base64 encode the resutls and display to the console.

            var inputMessage1 = "Hello, World!";
            var inputMessage1AsByteArray = Encoding.UTF8.GetBytes(inputMessage1);

            var inputMessage2 = "Hello, World";
            var inputMessage2AsByteArray = Encoding.UTF8.GetBytes(inputMessage2);

            var key1 = Hmac.GenerateKey();
            var key2 = Hmac.GenerateKey();

            Console.WriteLine($"Hashes of '{inputMessage1}' with key1");
            CalculateAndDisplayHmac(inputMessage1AsByteArray, key1);

            Console.WriteLine($"Hashes of '{inputMessage2}' with key1");
            CalculateAndDisplayHmac(inputMessage2AsByteArray, key1);

            Console.WriteLine($"Hashes of '{inputMessage1}' with key2");
            CalculateAndDisplayHmac(inputMessage1AsByteArray, key2);

            Console.WriteLine($"Hashes of '{inputMessage2}' with key2");
            CalculateAndDisplayHmac(inputMessage2AsByteArray, key2);

            var fileData = File.ReadAllBytes("HMAC.dll");

            Console.WriteLine("Hashes of dll file with key1");
            CalculateAndDisplayHmac(fileData, key1);

            Console.WriteLine("Hashes of dll file with key2");
            CalculateAndDisplayHmac(fileData, key2);
        }

        private static void CalculateAndDisplayHmac(byte[] inputAsByteArray, byte[] key)
        {
            Console.WriteLine("MD5 = " + Convert.ToBase64String(Hmac.ComputeHmacmd5(inputAsByteArray, key)));
            Console.WriteLine("SHA1 = " + Convert.ToBase64String(Hmac.ComputeHmacSha1(inputAsByteArray, key)));
            Console.WriteLine("SHA256 = " + Convert.ToBase64String(Hmac.ComputeHmacSha256(inputAsByteArray, key)));
            Console.WriteLine("SHA512 = " + Convert.ToBase64String(Hmac.ComputeHmacSha512(inputAsByteArray, key)));
            Console.WriteLine(Environment.NewLine);
        }
    }
}
