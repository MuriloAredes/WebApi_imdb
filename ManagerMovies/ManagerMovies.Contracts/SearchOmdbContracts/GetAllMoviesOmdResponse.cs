namespace ManagerMovies.Contracts.SearchOmdbContracts
{
    public class GetAllMoviesOmdResponse
    {
        public string ImdbId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DateRelease { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;  
        public string ImdbRating { get; set; } = string.Empty;
    }
}
