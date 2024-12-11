using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Controllers;

[ApiController]
public class MovieController : ControllerBase
{
   private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost(ApiEndpoints.Movies.Create)]
    public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
    {
        var movie = request.MapToMovie();
        return await _movieService.CreateAsync(movie) 
            ? CreatedAtAction(nameof(Get), new { idOrSlug = movie.Id }, movie.MapToResponse()) : BadRequest();
    }
    
    [HttpGet(ApiEndpoints.Movies.Get)]
    public async Task<IActionResult> Get([FromRoute] string idOrSlug)
    {
        var existingMovie = await _movieService.GetBySlugAsync(idOrSlug);
        return  existingMovie != null ? Ok(existingMovie.MapToResponse()) : NotFound();
    }

    [HttpPut(ApiEndpoints.Movies.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
    {
        var movie = request.MapToMovie(id);
        return await _movieService.UpdateAsync(movie) ? NoContent() : BadRequest();
    }

    [HttpGet(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieService.GetAllAsync();
        var items = new MoviesResponse { Items = movies.Select( x => x.MapToResponse()) };
        return Ok(items);
    }
    
    
    [HttpDelete(ApiEndpoints.Movies.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var isDeleted = await _movieService.DeleteByIdAsync(id);
        return isDeleted ? NoContent() : NotFound();
    }
}