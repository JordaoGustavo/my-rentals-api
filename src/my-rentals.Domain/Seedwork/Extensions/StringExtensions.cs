using System.Security.Cryptography;
using System.Text;

namespace my_rental.Domain.Seedwork.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert to Hash 256 string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHash256(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            using SHA256 sHA256 = SHA256.Create();
            byte[] byteArray = sHA256.ComputeHash(Encoding.ASCII.GetBytes(value));
            return Encoding.ASCII.GetString(byteArray);
        }
    }
}
