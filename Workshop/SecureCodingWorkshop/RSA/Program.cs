using System;
using System.Text;

namespace SecureCodingWorkshop.RSA
{
    static class Program
    {
        private static void Main()
        {
            // TODO : Generate a new set of RSA keys
            // TODO : Use the RSA with Parameter Keys technique to encrypt a short string.

            var rsa = new RSAWithRSAParameterKey();

            rsa.AssignNewKey();

            var input = "Hello, World!";
            var inputAsBytes = Encoding.UTF8.GetBytes(input);

            var encrypted = rsa.EncryptData(inputAsBytes);
            var decrypted = rsa.DecryptData(encrypted);

            Console.WriteLine($"Input = '{input}'");
            Console.WriteLine($"Encrypted = {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Decrypted = {Encoding.UTF8.GetString(decrypted)}");

            Console.WriteLine($"PublicKey = {Convert.ToBase64String(rsa.PublicKey.Modulus)}");
            Console.WriteLine($"PrivateKey P = {Convert.ToBase64String(rsa.PrivateKey.P)}");
            Console.WriteLine($"PrivateKey Q = {Convert.ToBase64String(rsa.PrivateKey.Q)}");
        }
    }
}
