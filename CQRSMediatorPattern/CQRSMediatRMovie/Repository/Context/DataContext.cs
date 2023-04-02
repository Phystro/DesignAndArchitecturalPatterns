namespace CQRSMediatRMovie.Repository.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
