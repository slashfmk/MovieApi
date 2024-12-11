using Microsoft.EntityFrameworkCore;
using Movies.Application.Models;

namespace Movies.Application.Database;

public class MovieContext: DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
}