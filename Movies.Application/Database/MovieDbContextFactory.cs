using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Movies.Application.Database;

public class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
{
    public MovieDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost; Database=MovieRating; User Id=SA; Password=Password7!; TrustServerCertificate=true");

        return new MovieDbContext(optionsBuilder.Options);
    }
}