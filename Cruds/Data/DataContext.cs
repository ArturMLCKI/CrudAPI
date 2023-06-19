using DevExpress.Data.Browsing;
using Microsoft.EntityFrameworkCore;

namespace Cruds.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext>options): base(options) { }
        
            public DbSet<Produkty> Produktys { get; set; }
    
    }
}
