using Movies.Application.Dtos.Requests;
using Movies.Application.Dtos.Responses;
using Movies.Application.Models;
using Movies.Contracts.Responses;

namespace Movies.Api.Mapping;

public static class ContractMapping
{
    public static Movie MapToMovie(this CreateMovieRequest request)
    {
        return new Movie
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
            // MovieGenres = request.Genres
        };
    }

    public static Movie MapToMovie(this UpdateMovieRequest request, Guid id)
    {
        return new Movie
        {
            Id = id,
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
            // MovieGenres = request.Genres.ToList()
        };
    }

    public static MovieResponse MapToResponse(this Movie movie)
    {
        return new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Slug = movie.Slug,
            YearOfRelease = movie.YearOfRelease,
            Genres = null
        };
    }

    public static MoviesResponse MapToResponse(this IEnumerable<Movie> movies)
    {
        return new MoviesResponse { Items = movies.Select(MapToResponse) };
    }


    /*
     ****** Genre mapping ******
     */
    public static Genre MapToGenre(this CreateGenreRequest request)
    {
        return new Genre
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description
        };
    }

    public static Genre MapToGenre(this UpdateGenreRequest request, Guid id)
    {
        return new Genre
        {
            Id = id,
            Title = request.Title,
            Description = request.Description
        };
    }

    public static GenreResponse MapToResponse(this Genre genre)
    {
        return new GenreResponse
        {
            Id = genre.Id,
            Title = genre.Title,
            Description = genre.Description
        };
    }

    public static GenresResponse MapToResponse(this IEnumerable<Genre> movies)
    {
        return new GenresResponse { Items = movies.Select(MapToResponse) };
    }

    /********
     * User
     */

    // public static UserResponse MapToResponse(this User user)
    // {
    //     return new UserResponse
    //     {
    //         Id = user.Id,
    //         Firstname = user.,
    //         Lastname = user.LastName,
    //         Email = user.Email,
    //     };
    // }
    //
    // public static User MapToUser(this CreateUser user)
    // {
    //     return new User
    //     {
    //         Id = Guid.NewGuid(),
    //         Email = user.Email,
    //         Password = user.Password,
    //         FirstName = user.Firstname,
    //         LastName = user.Lastname
    //     };
    // }
}