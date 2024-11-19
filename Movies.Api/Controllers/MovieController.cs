using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Models;
using Movies.Application.Repository;
using Movies.Contracts.Requests;

namespace Movies.Api.Controllers;


[ApiController]
public class MovieController: ControllerBase
{

    private readonly IMovieRepository _movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpPost(ApiEndpoints.Movies.Create)]
    public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
    {
        
        var movie = request.MapToMovie();

        await _movieRepository.CreateAsync(movie);
        
        return Created($"{ApiEndpoints.Movies.Create}/{movie.Id}", movie);
    }
}