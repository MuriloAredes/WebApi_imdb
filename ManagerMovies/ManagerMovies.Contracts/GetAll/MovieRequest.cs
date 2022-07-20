using ManagerMovies.Domain.Enum;

namespace ManagerMovies.Contracts.GetAll
{
    public class MovieRequest
    {
        public string? Search { get; set; } = string.Empty;
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool IsAsc { get; set; }
        public MovieEnum ColunmSort { get; set; }
    }
}
