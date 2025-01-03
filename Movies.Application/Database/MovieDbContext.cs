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
        
        // Movie
        var movies = modelBuilder.Entity<Movie>();
        movies.Property(p => p.Title).HasMaxLength(50).IsRequired();
        movies.Property(p => p.YearOfRelease).HasDefaultValue(new DateOnly().Year);

        // Genre
        var genre = modelBuilder.Entity<Genre>();

        genre.Property(p => p.Title).HasMaxLength(50).IsRequired();
        genre.Property(p => p.Description).HasMaxLength(150).IsRequired();
        
        genre.HasData(
            new Genre {Id = Guid.NewGuid(), Title = "Action", Description = "Action" },
            new Genre {Id = Guid.NewGuid() , Title = "Adventure", Description = "Adventure" },
            new Genre {Id = Guid.NewGuid() , Title = "Drama", Description = "Drama" },
            new Genre {Id = Guid.NewGuid() , Title = "Fantasy", Description = "Fantasy" },
            new Genre {Id = Guid.NewGuid() , Title = "Horror", Description = "Horror" },
            new Genre {Id = Guid.NewGuid() , Title = "Romance", Description = "Romance" },
            new Genre {Id = Guid.NewGuid() , Title = "Science Fiction", Description = "Science Fiction" },
            new Genre {Id = Guid.NewGuid() , Title = "Thriller", Description = "Thriller" }
        );
    }
}