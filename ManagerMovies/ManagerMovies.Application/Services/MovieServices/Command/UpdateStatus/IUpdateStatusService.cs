using ManagerMovies.Contracts;

namespace ManagerMovies.Application.Services.MovieServices.Command.UpdateStatus
{
    public interface IUpdateStatusService
    {
        Task<SucessMessageOrErrorResponse> UpdateStatus(int id);
    }
}
