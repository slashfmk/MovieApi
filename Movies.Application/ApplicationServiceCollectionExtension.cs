using Microsoft.Extensions.DependencyInjection;
using Movies.Api.Repository;

namespace Movies.Application;

public static class ApplicationServiceCollectionExtension
{

     public static IServiceCollection AddApplication(this IServiceCollection services)
     {
         services.AddSingleton<IMovieRepository, MovieRepository>();
         
         return services;
     }
}