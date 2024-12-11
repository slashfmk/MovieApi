using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Models;

namespace Movies.Application.Services;

public class MovieService : IMovieService
{
    private readonly IValidator<Movie> _movieValidator;
    private readonly MovieContext _context;

    public MovieService(IValidator<Movie> movieValidator, MovieContext context)
    {
        _movieValidator = movieValidator;
        _context = context;
    }


    public async Task<bool> CreateAsync(Movie movie)
    {
        await _movieValidator.ValidateAndThrowAsync(movie);

        await _context.Movies.AddAsync(movie);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return null;
        return movie;
    }

    public async Task<Movie?> GetBySlugAsync(string slug)
    {
        var movie = Guid.TryParse(slug, out var id)
            ? await _context.Movies.FirstOrDefaultAsync(m => m.Id == id)
            : await _context.Movies.FirstOrDefaultAsync(m => m.Slug == slug);

        return movie;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Movie movie)
    {
        await _movieValidator.ValidateAndThrowAsync(movie);
        ;
        var foundMovie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);

        if (foundMovie == null) return false;
        foundMovie = movie;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var foundMovie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (foundMovie == null) return false;

        _context.Movies.Remove(foundMovie);
        await _context.SaveChangesAsync();
        return true;
    }
}