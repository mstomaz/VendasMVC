using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<MVCVendasWeb.Models.Department> Department { get; set; } = default!;
    }
}
