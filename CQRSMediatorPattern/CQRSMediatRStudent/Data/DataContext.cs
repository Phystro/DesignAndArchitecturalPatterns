using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CQRSMediatRStudent.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
           base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DataContext"));
        }

        public DbSet<StudentDetails> Students { get; set; } = null!;
    }
}