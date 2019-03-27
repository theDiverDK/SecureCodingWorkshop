using System;
using System.Buffers.Text;

namespace SecureCodingWorkshop.RandomNumber
{
    static class Program
    {
        static void Main()
        {
            // TODO : Generate 10 random numbers using RNGCryptoServiceProvider.            
            // TODO : Convert the resulting byte arrays into base64 strings and print to the console.


            for (var i = 0; i < 10; i++)
            {
                var randomNumber = Random.GenerateRandomNumber(32);

                var result = Convert.ToBase64String(randomNumber);

                Console.WriteLine($"Random number {i}: {result}");
            }
        }
    }
}