namespace Movies.Application.Models;

public class Genre
{
     public Guid Id { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }

     public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}