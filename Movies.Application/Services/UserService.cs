using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Dtos.Requests;
using Movies.Application.Models;

namespace Movies.Application.Services;

public class UserService
{
    private readonly MovieDbContext _context;
   // private readonly PasswordService _passwordService;

    public UserService(MovieDbContext context)
    {
        _context = context;
       // _passwordService = passwordService;
    }

    public async Task<bool> CreateAsync(CreateUser createUser, CancellationToken cancellationToken = default)
    {
        var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == createUser.Email, cancellationToken);
        if (userExists is null) return false;

        var newUser = new User
        {
            // FirstName = createUser.Firstname,
            // LastName = createUser.Lastname,
            Email = createUser.Email,
          //  Password = _passwordService.CreateHashedPassword(createUser.Password)
        };

        await _context.Users.AddAsync(newUser, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        return userExists;
    }
    

    private async Task<bool?> UserExists(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }
}