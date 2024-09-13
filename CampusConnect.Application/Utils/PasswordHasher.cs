using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace CampusConnect.Application.Utils
{
    public class PasswordHasher
    {
        public PasswordHasher()
        {

        }

        public string EncryptPassword(string Password)
        {
            byte[] saltByte = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltByte);
            }

            string hashedSalt = Convert.ToBase64String(saltByte);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: saltByte,
                 prf: KeyDerivationPrf.HMACSHA256,
                 iterationCount: 10000,
                 numBytesRequested: 256 / 8
                ));


            return $"{hashedSalt}${hashedPassword}";

        }

        public bool VerifyPassword(string inputPassword, string storedPassword)
        {

            if (string.IsNullOrEmpty(storedPassword))
            {
                // Handle the case where storedPassword is null or empty
                throw new ArgumentException("Stored password cannot be null or empty.");
            }

            // Split the stored password into salt and hashed password
            var parts = storedPassword.Split('$');
            if (parts.Length != 2)
            {
                // Log the storedPassword value for debugging
                Console.WriteLine($"Stored password format is incorrect. Stored password: {storedPassword}");
                return false; // Indicate failure
            }

            string salt = parts[0];
            string storedHashedPassword = parts[1];

            try
            {
                // Convert the salt from Base64 string to byte array
                byte[] saltByte = Convert.FromBase64String(salt);

                // Hash the input password with the same salt
                string inputHashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: inputPassword,
                    salt: saltByte,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                ));

                // Compare the hashed passwords
                return storedHashedPassword == inputHashedPassword;
            }
            catch (FormatException ex)
            {
                // Log detailed exception for debugging
                Console.WriteLine($"Error processing password: {ex.Message}");
                return false; // Indicate failure
            }
        }
    }
}
