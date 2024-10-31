using Movies.Api.Models;

namespace Movies.Api.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies = new();


    public Task<bool> CreateAsync(Movie movie)
    {
        _movies.Add(movie);
        return Task.FromResult(true);
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        return Task.FromResult(movie);
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return Task.FromResult(_movies.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Movie movie)
    {
        var movieIndex = _movies.FindIndex(m => m.Id == movie.Id);

        if (movieIndex == -1) return Task.FromResult(false);

        _movies[movieIndex] = movie;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removeCount = _movies.RemoveAll(m => m.Id == id);
        var movieRemoved = removeCount > 0;

        return Task.FromResult(movieRemoved);
    }
}