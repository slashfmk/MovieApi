using FluentValidation;
using FluentValidation.Validators;
using Movies.Application.Models;
using Movies.Application.Services;

namespace Movies.Application.Validators;

public class MovieValidator : AbstractValidator<Movie>
{
    private readonly IMovieService _movieService;

    public MovieValidator(IMovieService movieService)
    {
        _movieService = movieService;

        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.Title).NotEmpty();
        RuleFor(m => m.Genres).NotEmpty();
        RuleFor(m => m.YearOfRelease).LessThanOrEqualTo(DateTime.UtcNow.Year);

        RuleFor(m => m.Slug)
            .MustAsync(ValidateSlug)
            .WithMessage("This movie already exists in the system!");
    }

    private async Task<bool> ValidateSlug(Movie movie, string slug, CancellationToken cancellationToken = default)
    {
        var existinggMovie = await _movieService.GetBySlugAsync(slug);

        if (existinggMovie is not null)
        {
            return existinggMovie.Id == movie.Id;
        }

        return existinggMovie is not null;
    }
}