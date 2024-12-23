using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
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


    public async Task<bool> CreateAsync(Movie movie)
    {
        await _movieValidator.ValidateAndThrowAsync(movie);

        await _dbContext.Movies.AddAsync(movie);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return null;
        return movie;
    }

    public async Task<Movie?> GetBySlugAsync(string slug)
    {
        var movie = Guid.TryParse(slug, out var id)
            ? await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id)
            : await _dbContext.Movies.FirstOrDefaultAsync(m => m.Slug == slug);

        return movie;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Movie movie)
    {
        await _movieValidator.ValidateAndThrowAsync(movie);
        ;
        var foundMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);

        if (foundMovie == null) return false;
        foundMovie = movie;
        
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var foundMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (foundMovie == null) return false;

        _dbContext.Movies.Remove(foundMovie);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}