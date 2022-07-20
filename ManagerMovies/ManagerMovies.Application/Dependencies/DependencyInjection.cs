
using ManagerMovies.Application.Services.MovieServices.Command.Create;
using ManagerMovies.Application.Services.MovieServices.Command.Remove;
using ManagerMovies.Application.Services.MovieServices.Command.Update;
using ManagerMovies.Application.Services.MovieServices.Command.UpdateStatus;
using ManagerMovies.Application.Services.MovieServices.Queries.GetAll;
using Microsoft.Extensions.DependencyInjection;

namespace ManagerMovies.Application.Dependencies
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddScoped<IRegisterMovieService, RegisterMovieService>();
            services.AddScoped<IRemoveMovieService ,RemoveMovieService> ();
            services.AddScoped<IUpdateMovieService, UpdateMovieService> ();
            services.AddScoped<IGetAllMoviesService, GetAllMoviesService>();
            services.AddScoped<IUpdateStatusService, UpdateStatusService>();
         
            return services;
        }

    }
}
