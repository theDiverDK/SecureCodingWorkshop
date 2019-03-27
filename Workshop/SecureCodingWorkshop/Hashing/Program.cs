using System;
using System.IO;
using System.Text;

namespace SecureCodingWorkshop.Hashing
{
    static class Program
    {
        static void Main()
        {
            // TODO : Calculate MD5, SHA1, SHA256 and SHA512 hashes for a series of strings
            // TODO : Base64 encode the results and display to the console.
            var input = "Hello, World!";
            var inputAsByteArray = Encoding.UTF8.GetBytes(input);
            Console.WriteLine($"Hashes of {input}");
            CalculateAndDisplayHashes(inputAsByteArray);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Hashes of dll file");
            var fileData = File.ReadAllBytes("Hashing.dll");
            CalculateAndDisplayHashes(fileData);
        }

        private static void CalculateAndDisplayHashes(byte[] inputAsByteArray)
        {
            Console.WriteLine("MD5 = " + Convert.ToBase64String(HashData.ComputeHashMd5(inputAsByteArray)));
            Console.WriteLine("SHA1 = " + Convert.ToBase64String(HashData.ComputeHashSha1(inputAsByteArray)));
            Console.WriteLine("SHA256 = " + Convert.ToBase64String(HashData.ComputeHashSha256(inputAsByteArray)));
            Console.WriteLine("SHA512 = " + Convert.ToBase64String(HashData.ComputeHashSha512(inputAsByteArray)));
        }
    }
}
