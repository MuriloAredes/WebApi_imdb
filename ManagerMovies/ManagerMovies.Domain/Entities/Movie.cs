using System.ComponentModel.DataAnnotations;

namespace ManagerMovies.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string ImdbId { get; set; } = string.Empty;
        public string  Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateRelease { get; set; }
        public string Genre { get; set; } = string.Empty; 
        public bool Watched { get; set; }
        public float? UserScore { get; set; }
        public string ImdbRating { get; set; } = string.Empty;
        public bool Delete { get; set; }
    }
}
