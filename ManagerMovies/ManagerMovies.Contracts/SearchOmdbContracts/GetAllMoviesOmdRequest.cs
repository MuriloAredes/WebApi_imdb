

namespace ManagerMovies.Contracts.SearchOmdbContracts
{
    public class GetAllMoviesOmdRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public int year { get; set; }

    }
}
