using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace SecureCodingWorkshop.DigitalSignature
{
    static class Program
    {
        private static void Main()
        {
            // TODO : Take a document (that is a string and convert it to a byte array
            // TODO : Hash that document with sha256
            // TODO : Create a new RSA key pair
            // TODO : Create a digital signature of the hash

            // TODO : Check that you can verify the signature correctly.
            // TODO : Tamper with the document and then try to re-verify the signature.

            var input = "Hello, World!";

            var hash = ComputeHashSha256(Encoding.UTF8.GetBytes(input));

            var rsa = new DigitalSignature();
            rsa.AssignNewKey();

            var digitalSignatur = rsa.SignData(hash);

            var isValid = rsa.VerifySignature(hash, digitalSignatur);
            Console.WriteLine("Untampered");
            Console.WriteLine($"The Signature is valid {isValid}");
            Console.WriteLine();
            Console.WriteLine("Tampered");

            input = $"{input}."; //Added . to input
            var tamperedHash = ComputeHashSha256(Encoding.UTF8.GetBytes(input));
            isValid = rsa.VerifySignature(tamperedHash, digitalSignatur);
            Console.WriteLine($"The Signature is valid {isValid}");
        }

        public static byte[] ComputeHashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }
    }
}
