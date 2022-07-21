using ManagerMovies.Contracts.SearchOmdbContracts;

namespace ManagerMovies.Application.Services.SearchOmdbServices.Query.GetAllService
{
   public interface IGetAllMoviesOmdbService
    {
        public Task<GetAllMoviesOmdResponse> GetAll(GetAllMoviesOmdRequest request);
    }
}
