using ManagerMovies.Domain.Entities;

namespace ManagerMovies.Application.Persistence
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Task<Movie?> GetMovieById(int id);
        Movie? Get(string imdbId);
        Task Add(Movie movie);
        void Remove(string id);
        Task Update(Movie movie);
        Task Commit();
    }
}
