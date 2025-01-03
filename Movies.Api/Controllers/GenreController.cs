using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Dtos.Requests;
using Movies.Application.Dtos.Responses;
using Movies.Application.Services;

namespace Movies.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class GenreController: ControllerBase
{
    
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpPost(ApiEndpoints.Genres.Create)]
    public async Task<IActionResult> Create([FromBody] CreateGenreRequest request, CancellationToken cancellationToken)
    {
        var genre = request.MapToGenre();
        return await _genreService.CreateAsync(genre, cancellationToken) 
            ? CreatedAtAction(nameof(Get), new { Id = genre.Id }, genre.MapToResponse()) : BadRequest();
    }
    
    [HttpGet(ApiEndpoints.Genres.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var existingMovie = await _genreService.GetByIdAsync(id, cancellationToken);
        return  existingMovie != null ? Ok(existingMovie.MapToResponse()) : NotFound();
    }

    [HttpPut(ApiEndpoints.Genres.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGenreRequest request, CancellationToken cancellationToken)
    {
        var genre = request.MapToGenre(id);
        return await _genreService.UpdateAsync(genre, cancellationToken) ? NoContent() : BadRequest();
    }

    [HttpGet(ApiEndpoints.Genres.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var genres = await _genreService.GetAllAsync(cancellationToken);
        var response = new GenresResponse { Items = genres.Select(g => g.MapToResponse()) };
        return Ok(response);
    }
    
    
    [HttpDelete(ApiEndpoints.Genres.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var isDeleted = await _genreService.DeleteByIdAsync(id, cancellationToken);
        return isDeleted ? NoContent() : NotFound();
    }
    
}