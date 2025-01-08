using System.Text.Json.Serialization;

namespace Movies.Application.Models;

public class Genre
{
     public Guid Id { get; set; }
     public string Title { get; set; } = String.Empty;
     public string Description { get; set; } = String.Empty;

     public ICollection<MovieGenre>? MovieGenres { get; set; }
}