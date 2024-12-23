using Movies.Application.Models;

namespace Movies.Application.Dtos.Requests;

public sealed class CreateMovieRequest
{
    public required string Title { get; init; }
    public required int YearOfRelease { get; init; }
   // public IEnumerable<Genre> Genres { get; set; }
}