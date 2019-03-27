using System;
using System.Text;

namespace SecureCodingWorkshop.AES
{
    static class Program
    {
        static void Main(string[] args)
        {
            // TODO : Generate a 32 byte key
            // TODO : Generate a 16 byte initialization vector
            // TODO : Encrypt some text, base64 the result and display to the console.
            // TODO : Decrypt the encrypted text, base64 the result and display to the console.

            var key = AesEncryption.GenerateRandomNumber(32);
            var iv = AesEncryption.GenerateRandomNumber(16);

            var input = "Hello, World!";
            var inputAsBytes = Encoding.UTF8.GetBytes(input);

            var encrypted = AesEncryption.Encrypt(inputAsBytes, key, iv);
            var decrypted = AesEncryption.Decrypt(encrypted, key, iv);

            Console.WriteLine($"'{input}'");
            Console.WriteLine($"encrypted = '{Convert.ToBase64String(encrypted)}'");
            Console.WriteLine($"decrypted = '{Encoding.UTF8.GetString(decrypted)}'");
        }
    }
}
