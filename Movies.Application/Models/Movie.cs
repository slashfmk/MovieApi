using System.Text.RegularExpressions;

namespace Movies.Application.Models;

public class Movie
{
    public Guid Id { get; init; }
    public string Title { get; set; }
    public int YearOfRelease { get; set; }
    
    public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    public string Slug => GenerateSlug();
    
    public string GenerateSlug()
    {
        var sluggedTitle = Regex.Replace(Title, @"[^0-9A-Za-z0 _-]", string.Empty)
            .ToLower().Replace(" ", "-");

        return $"{sluggedTitle}-{YearOfRelease}";
    }
    
}