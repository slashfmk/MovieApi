using Movies.Contracts.Responses;

namespace Movies.Application.Dtos.Responses;

public sealed class MoviesResponse
{
    public required IEnumerable<MovieResponse> Items { get; init; } = Enumerable.Empty<MovieResponse>();
}