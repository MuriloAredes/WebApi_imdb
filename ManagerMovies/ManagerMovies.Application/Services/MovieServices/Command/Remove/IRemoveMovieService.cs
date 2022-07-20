using ManagerMovies.Contracts;
using ManagerMovies.Contracts.Remove;

namespace ManagerMovies.Application.Services.MovieServices.Command.Remove
{
    public interface IRemoveMovieService
    {
        Task<SucessMessageOrErrorResponse> Remover(RemoveMovieRequest id);
    }
}
