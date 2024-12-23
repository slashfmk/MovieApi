using Movies.Application.Models;

namespace Movies.Contracts.Responses;

public sealed class MovieResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Slug { get; init; }
    public required int YearOfRelease { get; init; }
    public required IEnumerable<Genre> Genres { get; init; }
}