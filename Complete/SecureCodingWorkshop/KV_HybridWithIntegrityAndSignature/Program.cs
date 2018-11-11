﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AzureKeyVault.HybridWithIntegrityAndSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyVault().GetAwaiter().GetResult();
        }
         
        public static async Task KeyVault()
        {
            const string original = "Very secret information.";

            IKeyVault vault = new KeyVault();

            const string MY_KEY_NAME = "MyKey";
            string keyId = await vault.CreateKeyAsync(MY_KEY_NAME);

            var hybrid = new HybridEncryption(vault);

            Console.WriteLine("Hybrid Encryption with Key Vault");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            try
            {
                var encryptedBlock = hybrid.EncryptData(Encoding.UTF8.GetBytes(original), keyId);

                var decrpyted = hybrid.DecryptData(encryptedBlock, keyId);

                Console.WriteLine("Original Message = " + original);
                Console.WriteLine();
                Console.WriteLine("Message After Decryption = " + Encoding.UTF8.GetString(decrpyted));
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
