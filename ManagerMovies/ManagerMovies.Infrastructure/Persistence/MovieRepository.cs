using ManagerMovies.Application.Persistence;
using ManagerMovies.Domain.Entities;
using ManagerMovies.Infrastructure.Data;

namespace ManagerMovies.Infrastructure.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;
        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Movie movie)
        {
           await _context.movies.AddAsync(movie);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Movie? Get(string imdbId)
        {
            var movie = _context.movies.FirstOrDefault(e => e.ImdbId.Equals(imdbId));
            return movie; 
        }

        public IEnumerable<Movie> GetAll()
        {
            var movies = _context.movies.ToList();
            return movies;
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var movie = await _context.movies.FindAsync(id);
            return movie;
        }

        public void Remove(string id)
        {
            var movie = _context.movies.Find(id);

            if (movie != null)
                _context.movies.Remove(movie);
        }

        public async Task Update(Movie movie)
        {
           var result = await _context.movies.FindAsync(movie.Id);
           
            if (result != null)
                _context.movies.Update(movie);
            
        }

      
    }
}
