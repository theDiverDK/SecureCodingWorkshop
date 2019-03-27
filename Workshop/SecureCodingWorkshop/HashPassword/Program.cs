using System;
using System.Text;

namespace SecureCodingWorkshop.HashPassword
{
    static class Program
    {
        static void Main()
        {
            // TODO : Create a hashed password that is combine with a salt.
            // TODO : Base64 encode the result and display to the console.

            var password = "P@ssw0rd"; //Very secure :-)

            var salt1 = Hash.GenerateSalt();
            var salt2 = Hash.GenerateSalt();

            var hashAndSalt1 = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt1);
            var hashAndSalt2 = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt2);

            Console.WriteLine($"The password: '{password}' hash and salted with salt 1 = {Convert.ToBase64String(hashAndSalt1)}");
            Console.WriteLine($"The password: '{password}' hash and salted with salt 2 = {Convert.ToBase64String(hashAndSalt2)}");

        }
    }
}