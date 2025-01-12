using Microsoft.EntityFrameworkCore;
using MVCVendasWeb.Models;

namespace MVCVendasWeb.Data
{
    public class MVCVendasWebContext : DbContext
    {
        public MVCVendasWebContext (DbContextOptions<MVCVendasWebContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Department> Seller { get; set; } = default!;
        public DbSet<Department> SalesRecord { get; set; } = default!;
    }
}
