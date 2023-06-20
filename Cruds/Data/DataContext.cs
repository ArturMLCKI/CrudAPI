using DevExpress.Data.Browsing;
using Microsoft.EntityFrameworkCore;

namespace Cruds.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext>options): base(options) { }
        
            public DbSet<Produkty> Produktys { get; set; }

            public DbSet<car> cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produkty>()
                .HasOne(e => e.car)
                .WithOne(e => e.Produkty)
                .HasPrincipalKey<car>(e => e.ProduktyId)
                .IsRequired();
        }

    }
}
