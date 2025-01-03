using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Dtos.Requests;
using Movies.Application.Dtos.Responses;
using Movies.Application.Services;

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
    public async Task<IActionResult> Create([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
    {
        var movie = request.MapToMovie();
        return await _movieService.CreateAsync(movie, cancellationToken)
            ? CreatedAtAction(nameof(Get), new { idOrSlug = movie.Id }, movie.MapToResponse())
            : BadRequest();
    }

    [HttpGet(ApiEndpoints.Movies.Get)]
    public async Task<IActionResult> Get([FromRoute] string idOrSlug, CancellationToken cancellationToken)
    {
        var existingMovie = await _movieService.GetBySlugAsync(idOrSlug, cancellationToken);
        return existingMovie != null ? Ok(existingMovie.MapToResponse()) : NotFound();
    }

    [HttpPut(ApiEndpoints.Movies.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request,
        CancellationToken cancellationToken)
    {
        var movie = request.MapToMovie(id);
        return await _movieService.UpdateAsync(movie, cancellationToken) ? NoContent() : BadRequest();
    }

    [HttpGet(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var movies = await _movieService.GetAllAsync(cancellationToken);
        var items = new MoviesResponse { Items = movies.Select(x => x.MapToResponse()) };
        return Ok(movies);
    }


    [HttpDelete(ApiEndpoints.Movies.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var isDeleted = await _movieService.DeleteByIdAsync(id, cancellationToken);
        return isDeleted ? NoContent() : NotFound();
    }
}