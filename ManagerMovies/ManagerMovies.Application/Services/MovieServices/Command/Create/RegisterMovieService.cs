using ManagerMovies.Application.Persistence;
using ManagerMovies.Contracts;
using ManagerMovies.Contracts.Create;
using ManagerMovies.Domain.Entities;
using OMDbApiNet;

namespace ManagerMovies.Application.Services.MovieServices.Command.Create
{
    public class RegisterMovieService : IRegisterMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public RegisterMovieService(
            IMovieRepository movieRepository
            )
        {
            _movieRepository = movieRepository;

        }

        public async Task<SucessMessageOrErrorResponse> CreateMovie(RegisterMovieRequest request)
        {
            var omd = new AsyncOmdbClient("3a10b799");

            if (string.IsNullOrEmpty(request.ImdbId))
                return new SucessMessageOrErrorResponse("fill in id");

            var item = await omd.GetItemByIdAsync(request.ImdbId);

            // verificar se ja é existente 

            if (item == null)
                return new SucessMessageOrErrorResponse("incorrect id");

            var movie = new Movie
            {
                ImdbId = item.ImdbId,
                Name = item.Title,
                Description = item.Plot,
                DateRelease = Convert.ToDateTime(item.Released),
                Genre = item.Genre,
                ImdbRating = item.ImdbRating,
                Watched = false,
                UserScore = null,
                Delete = false

            };

            await _movieRepository.Add(movie);
            await _movieRepository.Commit();

            return new SucessMessageOrErrorResponse("Saved successfully");

        }


    }
}
