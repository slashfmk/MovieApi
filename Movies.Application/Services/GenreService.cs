using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Models;

namespace Movies.Application.Services;

public class GenreService: IGenreService
{
    
    private readonly MovieDbContext _dbContext;

    public GenreService(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    

    public async Task<bool> CreateAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync(genre, cancellationToken);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Genre?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Genres.ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        var genreToUpdate = await _dbContext.Genres.FirstOrDefaultAsync(g => genre.Id == g.Id, cancellationToken);

        if (genreToUpdate == null)
        {
            return false;
        }
        genreToUpdate.Description = genre.Description;
        genreToUpdate.Title = genre.Title;
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
        
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var genreToDelete = await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        if (genreToDelete == null)
        {
            return false;
        }
        _dbContext.Genres.Remove(genreToDelete);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
        
    }
}