using Movies.Application.Models;

namespace Movies.Application.Dtos.Requests;

public sealed class UpdateGenreRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}