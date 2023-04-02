
namespace CQRSMediatRMovie.Repository.Context
{
    public class DataContext : DbContext
    {
	public DataContext(DbContextOptions options) : base(options)
	{

	}

        public DbSet<Movie> Movies { get; set; } = null!;
    }
}
