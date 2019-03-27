using System;
using System.Diagnostics;
using System.Text;

namespace SecureCodingWorkshop.PBKDF2
{
    static class Program
    {
        public static void Main()
        {
            // TODO : Calculate a PBKDF2 hash for a password but with different levels of difficulty.
            // TODO : Base64 the results and display on the console.

            // TODO : For bonus points, time the results of each difficulty level and print to the console.

            var inputMessage1 = "Hello, World!";
            var inputMessage1AsByteArray = Encoding.UTF8.GetBytes(inputMessage1);
            var salt = PBKDF2.GenerateSalt();

            for (int i = 0; i < 24; i++)
            {
                var stopWatch = new Stopwatch();
                var iterations = 2<<i;

                stopWatch.Start();
                var result = PBKDF2.HashPassword(inputMessage1AsByteArray, salt, iterations);
                stopWatch.Stop();

                Console.WriteLine($"Hashing '{inputMessage1}' took {stopWatch.ElapsedMilliseconds}ms with {iterations} iterations, result = {Convert.ToBase64String( result)}");
            }
        }
    }
}
