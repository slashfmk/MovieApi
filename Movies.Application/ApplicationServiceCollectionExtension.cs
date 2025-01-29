using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Auth;
using Movies.Application.Database;
using Movies.Application.Services;
using Npgsql;

namespace Movies.Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IUserService, UserService>();
        services.AddSingleton<IPasswordService, PasswordService>();
        services.AddSingleton<TokenGenerator>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);

        return services;
    }
    
    public static IServiceCollection AddSqlServerDbContext(this IServiceCollection services, string connectionString)

    {
        services.AddDbContext<MovieDbContext>( options => options.UseSqlServer(connectionString));
        return services;
    }
    
}