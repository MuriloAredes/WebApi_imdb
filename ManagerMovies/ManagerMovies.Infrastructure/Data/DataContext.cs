using ManagerMovies.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagerMovies.Infrastructure.Data
{
    public class DataContext: DbContext
    {
        #region Entities 
        public virtual DbSet<Movie> movies { get; set; } 
        #endregion
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
        }
    }
}
