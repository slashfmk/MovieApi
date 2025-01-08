using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Dtos.Responses;
using Movies.Application.Models;

namespace Movies.Application.Services;

public class MovieService : IMovieService
{
    private readonly IValidator<Movie> _movieValidator;
    private readonly MovieDbContext _dbContext;

    public MovieService(IValidator<Movie> movieValidator, MovieDbContext dbContext)
    {
        _movieValidator = movieValidator;
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        await _movieValidator.ValidateAndThrowAsync(movie, cancellationToken);

        await _dbContext.Movies.AddAsync(movie, cancellationToken);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        if (movie == null) return null;
        return movie;
    }

    public async Task<Movie?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var movie = Guid.TryParse(slug, out var id)
            ? await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id, cancellationToken)
            : await _dbContext.Movies.FirstOrDefaultAsync(m => m.Slug == slug, cancellationToken);

        return movie;
    }
    
    public async Task<IEnumerable<MovieResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Movies
            .Select(m => new MovieResponse
            {
                Id = m.Id,
                Title = m.Title,
                Slug = m.Slug,
                YearOfRelease = m.YearOfRelease,
                Genres = m.MovieGenres.Select(g => new GenreResponse
                {
                    Id = g.Genre.Id,
                    Title = g.Genre.Title,
                    Description = g.Genre.Description
                })
            })
            .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<bool> UpdateAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        await _movieValidator.ValidateAndThrowAsync(movie, cancellationToken);

        var foundMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id, cancellationToken);

        if (foundMovie == null)
        {
            return false;
        }

        foundMovie.Title = movie.Title;
        foundMovie.YearOfRelease = movie.YearOfRelease;

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var foundMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        if (foundMovie == null) return false;

        _dbContext.Movies.Remove(foundMovie);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}