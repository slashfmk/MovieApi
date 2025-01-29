using System.Security.Cryptography;
using System.Text;

namespace Movies.Application.Services;

public class PasswordService: IPasswordService
{
    private readonly int _keySize = 64;
    private readonly int _iterations = 350000;
    private readonly  HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;
    
    public string CreateHashedPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(_keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, _iterations, _algorithm, _keySize);
        return Convert.ToHexString(hash);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithm, _keySize);
        return CryptographicOperations.FixedTimeEquals(hashCompare, salt);
    }
}