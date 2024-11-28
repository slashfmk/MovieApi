using System.Text.RegularExpressions;

namespace Movies.Application.Models;

public class Movie
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public string Slug => GenerateSlug();
    public required int YearOfRelease { get; set; }
    public required List<string> Genres { get; init; } = new();

    public string GenerateSlug()
    {
        var sluggedTitle = Regex.Replace(Title, @"[^0-9A-Za-z0 _-]", string.Empty)
            .ToLower().Replace(" ", "-");

        return $"{sluggedTitle}-{YearOfRelease}";
    }

    // [GeneratedRegex("0-9A-Za-z _-", RegexOptions.NonBacktracking, 5)]
    // private static partial Regex SlugRegex();
}