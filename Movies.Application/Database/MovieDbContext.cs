using Microsoft.EntityFrameworkCore;
using Movies.Application.Models;

namespace Movies.Application.Database;

public class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<MovieGenre> MoviesGenres => Set<MovieGenre>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-many relationship for Movies and Genres
        var movieGenres = modelBuilder.Entity<MovieGenre>();

        movieGenres
            .HasKey(m => new { m.MovieId, m.GenreId });

        movieGenres
            .HasOne(mg => mg.Movie)
            .WithMany(mg => mg.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);

        movieGenres
            .HasOne(mg => mg.Genre)
            .WithMany(mg => mg.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

        modelBuilder.Entity<Movie>()
            .Property(p => p.Title)
            .IsRequired();

        // Role
        var roles = modelBuilder.Entity<Role>();
        roles.HasKey(r => r.Id);

        roles.HasMany(u => u.Users)
            .WithOne(r => r.Role)
            .HasForeignKey(fk => fk.Id);
        
        roles.HasData(
            new Role { Id = Guid.NewGuid(), Name = "admin", Description = "Have all the privileges" },
            new Role { Id = Guid.NewGuid(), Name = "normal", Description = "Regular user with the lowest privileges" },
            new Role { Id = Guid.NewGuid(), Name = "trusted", Description = "Trusted with some advanced privileges" }
        );
        
        
        // Users
        var users = modelBuilder.Entity<User>();
        users.HasKey( u => u.Id);
        
        users
            .HasOne(u => u.Role)
            .WithMany(u => u.Users)
            .HasForeignKey(fk => fk.RoleId);
        
        // users.Property(p => p.Role).HasDefaultValue("normal");

        // Movie
        var movies = modelBuilder.Entity<Movie>();
        movies.Property(p => p.Title).HasMaxLength(50).IsRequired();
        movies.Property(p => p.YearOfRelease).HasDefaultValue(new DateOnly().Year);

        //Ratings
        var ratings = modelBuilder.Entity<Rating>();
        ratings.HasKey(x => new { x.MovieId, x.UserId });

        ratings
            .HasOne(x => x.Movie)
            .WithMany(m => m.Ratings)
            .HasForeignKey(fk => fk.MovieId);

        ratings
            .HasOne(u => u.User)
            .WithMany(r => r.Ratings)
            .HasForeignKey(fk => fk.UserId);

        ratings.Property(p => p.RatedAt).HasDefaultValue(DateTime.Now);
        ratings.Property(p => p.RatingScore).IsRequired();

        // Genre
        var genre = modelBuilder.Entity<Genre>();

        genre.Property(p => p.Title).HasMaxLength(50).IsRequired();
        genre.Property(p => p.Description).HasMaxLength(150).IsRequired();

        genre.HasData(
            new Genre { Id = Guid.NewGuid(), Title = "Action", Description = "Action" },
            new Genre { Id = Guid.NewGuid(), Title = "Adventure", Description = "Adventure" },
            new Genre { Id = Guid.NewGuid(), Title = "Drama", Description = "Drama" },
            new Genre { Id = Guid.NewGuid(), Title = "Fantasy", Description = "Fantasy" },
            new Genre { Id = Guid.NewGuid(), Title = "Horror", Description = "Horror" },
            new Genre { Id = Guid.NewGuid(), Title = "Romance", Description = "Romance" },
            new Genre { Id = Guid.NewGuid(), Title = "Science Fiction", Description = "Science Fiction" },
            new Genre { Id = Guid.NewGuid(), Title = "Thriller", Description = "Thriller" }
        );
    }
}