﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AzureKeyVault.HybridWithIntegrityAndSignature
{
    static class Program
    {
        public static async Task Main()
        {
            await KeyVault();
        }

        private static async Task KeyVault()
        {
            const string original = "Very secret information.";

            var vault = new KeyVault();

            const string MY_KEY_NAME = "MyKey";
            var keyId = await vault.CreateKeyAsync(MY_KEY_NAME);

            var hybrid = new HybridEncryption(vault);

            Console.WriteLine("Hybrid Encryption with Key Vault");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            try
            {
                var encryptedBlock = await hybrid.EncryptData(Encoding.UTF8.GetBytes(original), keyId);

                var decrypted = await hybrid.DecryptData(encryptedBlock, keyId);

                Console.WriteLine("Original Message = " + original);
                Console.WriteLine();
                Console.WriteLine("Message After Decryption = " + Encoding.UTF8.GetString(decrypted));
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
    }
}
