using ManagerMovies.Contracts;
using ManagerMovies.Contracts.Update;

namespace ManagerMovies.Application.Services.MovieServices.Command.Update
{
    public interface IUpdateMovieService
    {
        Task<SucessMessageOrErrorResponse> Update(UpdateMovieRequest request);
    }
}
