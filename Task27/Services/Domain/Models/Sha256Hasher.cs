using System;
using System.Security.Cryptography;
using System.Text;
using Task27.Services.Domain.Models.Contracts;

namespace Task27.Services.Domain.Models
{
    public class Sha256Hasher : IHasher
    {
        public string GetHash(string text)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            string convertedHash = Convert.ToBase64String(hash);

            sha256.Dispose();

            return convertedHash;
        }
    }
}
