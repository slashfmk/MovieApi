
namespace Movies.Application.Dtos.Responses;

public sealed class GenresResponse
{
    public required IEnumerable<GenreResponse> Items { get; init; } = Enumerable.Empty<GenreResponse>();
}