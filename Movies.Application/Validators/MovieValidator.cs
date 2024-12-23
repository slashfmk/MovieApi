using FluentValidation;
using FluentValidation.Validators;
using Movies.Application.Models;
using Movies.Application.Services;

namespace Movies.Application.Validators;

public class MovieValidator : AbstractValidator<Movie>
{

    public MovieValidator()
    {

        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.Title).NotEmpty();
        // RuleFor(m => m.MovieGenres).NotEmpty();
        RuleFor(m => m.YearOfRelease).LessThanOrEqualTo(DateTime.UtcNow.Year);

        // var extraValidator = new ExtraValidator(IMovieService movieService);

        // RuleFor(m => m.Slug)
        //     .MustAsync()
        //     .WithMessage("This movie already exists in the system!");
    }

   
}


// public class ExtraValidator
// {
//     private readonly IMovieService _movieService;
//
//     public ExtraValidator(IMovieService movieService)
//     {
//         _movieService = movieService;
//     }
//
//     // _movieService = movieService;
//     
//     public async Task<bool> ValidateSlug(Movie movie, string slug, CancellationToken cancellationToken = default)
//     {
//         var existinggMovie = await _movieService.GetBySlugAsync(slug);
//
//         if (existinggMovie is not null)
//         {
//             return existinggMovie.Id == movie.Id;
//         }
//
//         return existinggMovie is not null;
//     }
// }