namespace Movies.Contracts.Responses;

public class MoviesResponse
{
    public required IEnumerable<string> Items { get; init; } = Enumerable.Empty<string>();
}