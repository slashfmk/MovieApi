using Microsoft.EntityFrameworkCore;
using Movies.Application.Models;

namespace Movies.Application.Database;

public class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<MovieGenre> MoviesGenres => Set<MovieGenre>();

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Many-to-many relationship for Movies and Genres
        modelBuilder.Entity<MovieGenre>()
            .HasKey(m => new { m.MovieId, m.GenreId });
        
        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(mg => mg.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);
        
        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(mg => mg.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);


        modelBuilder.Entity<Movie>()
            .Property(p => p.Title)
            .IsRequired();
        
    }
}