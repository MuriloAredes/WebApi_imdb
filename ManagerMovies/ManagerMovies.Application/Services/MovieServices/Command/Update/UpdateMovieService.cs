using ManagerMovies.Application.Persistence;
using ManagerMovies.Contracts;
using ManagerMovies.Contracts.Update;

namespace ManagerMovies.Application.Services.MovieServices.Command.Update
{
    public class UpdateMovieService: IUpdateMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async  Task<SucessMessageOrErrorResponse> Update(UpdateMovieRequest request)
        {
            if (request.Id < 0)
                return new SucessMessageOrErrorResponse("Incorret id");

            var movie = await _movieRepository.GetMovieById(request.Id);

            if(movie == null)
                return new SucessMessageOrErrorResponse("Not found 404");

            movie.Name =  String.IsNullOrEmpty(request.Name)? movie.Name: request.Name ;
            movie.Description = String.IsNullOrEmpty(request.Description)? movie.Description:request.Description;
            movie.DateRelease = request.DateRelease;
            movie.UserScore = request.UserScore;
            movie.Watched = request.Watched;

          
            await _movieRepository.Update(movie);
            await _movieRepository.Commit();

           return new SucessMessageOrErrorResponse("Successfully updated"); ;
        }
    }
}
