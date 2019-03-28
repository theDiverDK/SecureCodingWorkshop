using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureCodingWorkshop.HybridWithIntegrity
{
    static class Program
    {
        static void Main()
        {
            //The example provided is not good since we only have one public/private key pair
            var data = "Hello, World!";

            var rsaKey = new RSAWithRSAParameterKey();
            rsaKey.AssignNewKey();

            var aliceHybridEncryption = new HybridEncryption();
            var encryptedData = aliceHybridEncryption.EncryptData(Encoding.UTF8.GetBytes(data), rsaKey);

            //Data is transmitted
            Console.WriteLine("Encrypted Data: " + Convert.ToBase64String(encryptedData.EncryptedData));
            Console.WriteLine("Encrypted Session Key: " + Convert.ToBase64String(encryptedData.EncryptedSessionKey));
            Console.WriteLine("Initialization Vector: " + Convert.ToBase64String(encryptedData.Iv));
            Console.WriteLine("Hmac: " + Convert.ToBase64String(encryptedData.Hmac));

            var bobHybridEncryption = new HybridEncryption();
            var decryptedData = bobHybridEncryption.DecryptData(encryptedData, rsaKey);

            Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
            Console.WriteLine();
            Console.WriteLine("Tamper data");

            encryptedData.EncryptedData[encryptedData.EncryptedData.Length - 1] = 0;
            try
            {
                decryptedData = bobHybridEncryption.DecryptData(encryptedData, rsaKey);
                Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Data has been changed during transmission");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
