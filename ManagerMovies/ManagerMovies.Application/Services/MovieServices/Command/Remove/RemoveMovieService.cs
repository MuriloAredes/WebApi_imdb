using ManagerMovies.Application.Persistence;
using ManagerMovies.Contracts;
using ManagerMovies.Contracts.Remove;

namespace ManagerMovies.Application.Services.MovieServices.Command.Remove
{
    public class RemoveMovieService : IRemoveMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public RemoveMovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<SucessMessageOrErrorResponse> Remover(RemoveMovieRequest request)
        {
            var result = await _movieRepository.GetMovieById(request.Id);
            
            if (result == null)
                return new SucessMessageOrErrorResponse("Incorret id");

            result.Delete = true;

            await _movieRepository.Update(result);
            await _movieRepository.Commit();
            
            return new SucessMessageOrErrorResponse("successfully removed");
        }
    }
}
