using System.Security.Cryptography;
using System.Text;

namespace MyHealth.Application.Services.Security;

public class PasswordHasher
{
    public string Hash(string password)
    {
        return Convert.ToBase64String(
            SHA256.HashData(Encoding.UTF8.GetBytes(password)));
    }

    public bool Verify(string password, string hash)
    {
        return Hash(password) == hash;
    }
}