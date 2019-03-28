using System;
using System.Text;

namespace SecureCodingWorkshop.Hybrid
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

            var bobHybridEncryption = new HybridEncryption();
            var decryptedData = bobHybridEncryption.DecryptData(encryptedData, rsaKey);

            Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
        }
    }
}
