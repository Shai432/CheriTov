using System.Security.Cryptography;

namespace ChariTov
{
    public static class Utilities
    {
        public static string HashPassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

    }
}
