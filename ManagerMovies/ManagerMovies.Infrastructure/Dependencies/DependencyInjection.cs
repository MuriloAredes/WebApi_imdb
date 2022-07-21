using ManagerMovies.Application.Persistence;
using ManagerMovies.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ManagerMovies.Infrastructure.Dependencies

{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(
            this IServiceCollection services) 
        {
           
            services.AddScoped<IMovieRepository, MovieRepository>();
           
            return services;
        }
    }
}
