using Microsoft.EntityFrameworkCore;
using MVCVendasWeb.Models;

namespace MVCVendasWeb.Data
{
    public class DepartmentsContext : DbContext
    {
        public DepartmentsContext (DbContextOptions<DepartmentsContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
    }
}
