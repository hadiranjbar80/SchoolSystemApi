

using System.Security.Cryptography;
using System.Text;
using Domain.Models;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Schools.Any())
            {
                var rand = new Random();
                var schools = new List<School>
                {
                    new School
                    {
                        SchoolCode = rand.Next(0,1000).ToString(),
                        Name = "Test School",
                        Password = HashPassword("123456")
                    },
                    new School
                    {
                        SchoolCode = rand.Next(0,1000).ToString(),
                        Name = "Test School",
                        Password = HashPassword("123456")
                    },
                    new School
                    {
                        SchoolCode = rand.Next(0,1000).ToString(),
                        Name = "Test School",
                        Password = HashPassword("123456")
                    },
                    new School
                    {
                        SchoolCode = rand.Next(0,1000).ToString(),
                        Name = "Test School",
                        Password = HashPassword("123456")
                    },
                    new School
                    {
                        SchoolCode = rand.Next(0,1000).ToString(),
                        Name = "Test School",
                        Password = HashPassword("123456")
                    },
                    new School
                    {
                        SchoolCode = rand.Next(0,1000).ToString(),
                        Name = "Test School",
                        Password = HashPassword("123456")
                    },
                };
                await context.Schools.AddRangeAsync(schools);
                await context.SaveChangesAsync();
            }
        }

        public static string HashPassword(string text)
        { 
            using (MD5 md5 = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] inputBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                // Convert the byte array to a hexadecimal string.
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Format as hexadecimal
                }
                return sb.ToString();
            }
        }
    }
}