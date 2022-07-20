using ManagerMovies.Application.Persistence;
using ManagerMovies.Contracts;

namespace ManagerMovies.Application.Services.MovieServices.Command.UpdateStatus
{
    public class UpdateStatusService : IUpdateStatusService
    {
        private readonly IMovieRepository _movieRepository;
        public UpdateStatusService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async  Task<SucessMessageOrErrorResponse> UpdateStatus(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
           
            if (movie == null)
                return new SucessMessageOrErrorResponse("Incorret id");

            movie.Watched = true;

            await _movieRepository.Update(movie);
            await _movieRepository.Commit();

            return new SucessMessageOrErrorResponse("watched movie");
        }
    }
}
