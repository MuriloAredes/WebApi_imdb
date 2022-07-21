using ManagerMovies.Contracts;
using ManagerMovies.Contracts.Create;

namespace ManagerMovies.Application.Services.MovieServices.Command.Create
{
    public  interface IRegisterMovieService
    {
        Task<SucessMessageOrErrorResponse> RegisterMovie(RegisterMovieRequest request);
       
    }
}

