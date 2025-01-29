using Movies.Application.Dtos.Requests;
using Movies.Application.Models;

namespace Movies.Application.Services;


public interface IUserService
{
    public Task<bool> CreateAsync(CreateUser createUser, CancellationToken cancellationToken = default);
    public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    public Task<bool> UpdateAsync(Guid id, User user, CancellationToken cancellationToken = default);
}