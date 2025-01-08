using Movies.Application.Dtos.Responses;
using Movies.Application.Models;

namespace Movies.Application.Services;

public interface IMovieService
{
    Task<bool> CreateAsync(Movie movie, CancellationToken cancellationToken);
    Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Movie?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task<IEnumerable<MovieResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Movie movie, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}