using Movies.Application.Models;

namespace Movies.Application.Services;

public interface IGenreService
{
    Task<bool> CreateAsync(Genre genre, CancellationToken cancellationToken);
    Task<Genre?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Genre genre, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}