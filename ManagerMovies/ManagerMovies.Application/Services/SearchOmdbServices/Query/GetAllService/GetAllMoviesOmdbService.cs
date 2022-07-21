using ManagerMovies.Contracts.SearchOmdbContracts;
using OMDbApiNet;

namespace ManagerMovies.Application.Services.SearchOmdbServices.Query.GetAllService
{
    public class GetAllMoviesOmdbService : IGetAllMoviesOmdbService
    {
         
        public async Task<GetAllMoviesOmdResponse> GetAll(GetAllMoviesOmdRequest request)
        {
            string key = "3a10b799";
            var omdb = new AsyncOmdbClient(key);
           
            if (!string.IsNullOrEmpty(request.Title) )
            {

                var result = await omdb.GetItemByTitleAsync(request.Title, request.year, true);

                var movie = new GetAllMoviesOmdResponse
                {
                    ImdbId = result.ImdbId,
                    Title = result.Title,
                    Description = result.Plot,
                    DateRelease = result.Released,
                    Genre = result.Genre,
                    ImdbRating = result.ImdbRating
                };
                return movie;
            }

            if (!string.IsNullOrEmpty(request.Id))
            {

                var result = await omdb.GetItemByIdAsync(request.Title, true);

                var movie = new GetAllMoviesOmdResponse
                {
                    ImdbId = result.ImdbId,
                    Title = result.Title,
                    Description = result.Plot,
                    DateRelease = result.Released,
                    Genre = result.Genre,
                    ImdbRating = result.ImdbRating
                };
                return movie;
            }

            return new GetAllMoviesOmdResponse();
        }
    }
}
