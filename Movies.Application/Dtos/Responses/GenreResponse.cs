namespace Movies.Application.Dtos.Responses;

public sealed class GenreResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}