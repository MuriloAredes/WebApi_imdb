using ManagerMovies.Application.Persistence;
using ManagerMovies.Contracts.GetAll;
using ManagerMovies.Domain.Enum;

namespace ManagerMovies.Application.Services.MovieServices.Queries.GetAll
{
    public class GetAllMoviesService : IGetAllMoviesService
    {
        private readonly IMovieRepository _movieRepository;
        public GetAllMoviesService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
       
        public async Task<IEnumerable<MovieResponse>> GetAll(MovieRequest request)
        {
            var movies = _movieRepository.GetAll();

            var result = movies.Where(e => (string.IsNullOrEmpty(request.Search)||
                                            e.Name.Contains(request.Search) ||
                                            e.Genre.Contains(request.Search)) &&
                                            !e.Delete &&
                                            !e.Watched
                                            )
                                .Select(res => new MovieResponse 
                                {
                                    Id = res.Id,
                                    ImdbId = res.ImdbId,
                                    Name = res.Name,
                                    Description = res.Description,
                                    Genre = res.Genre,
                                    Watched = res.Watched,
                                    DateRelease = res.DateRelease,
                                    UserScore = res.UserScore,
                                    ImdbRating = res.ImdbRating
                                                                        
                                }).Skip((request.Page -1) * request.PageSize)
                                  .Take(request.PageSize).ToList();

            switch (request.ColunmSort) 
            {
                case MovieEnum.Name:
                    result = request.IsAsc ? result.OrderByDescending(n => n.Name).ToList() : result;
                    break;
               
                case MovieEnum.Genre:
                    result = request.IsAsc ? result.OrderByDescending(n => n.Genre).ToList() : result;
                    break;
                
                case MovieEnum.DateRelease:
                    result = request.IsAsc ? result.OrderByDescending(n => n.DateRelease).ToList() : result;
                    break;
            }
                 
            
            return  result;
        }
    }
}
