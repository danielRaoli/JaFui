using Microsoft.EntityFrameworkCore;
using ViagemApi.Model;

namespace ViagemApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depoimento>().Property(s => s.name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Depoimento>().Property(s => s.depoimento).IsRequired().HasMaxLength(300);

            modelBuilder.Entity<Depoimento>().Property(s => s.foto).IsRequired();
        }
        public DbSet<Depoimento> Depoimentos { get; set; }


    }
}
