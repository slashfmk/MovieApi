namespace Movies.Application.Services;

public interface IPasswordService
{
    public string CreateHashedPassword(string password, out byte[] salt);
    public bool VerifyPassword(string password, string hash, byte[] salt);
}