namespace ManagerMovies.Contracts.Update
{
    public class UpdateMovieRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateRelease { get; set; }
        public string Genre { get; set; } = string.Empty;
        public bool Watched { get; set; }
        public float? UserScore { get; set; }
    }
}
