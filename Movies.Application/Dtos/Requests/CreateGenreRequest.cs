using Movies.Application.Models;

namespace Movies.Application.Dtos.Requests;

public sealed class CreateGenreRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
}