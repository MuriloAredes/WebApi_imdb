using ManagerMovies.Contracts.GetAll;
using ManagerMovies.Domain.Entities;

namespace ManagerMovies.Application.Services.MovieServices.Queries.GetAll
{
    public interface IGetAllMoviesService
    {
        Task<IEnumerable<MovieResponse>> GetAll(MovieRequest request);
    }
}
