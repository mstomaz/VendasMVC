using Microsoft.EntityFrameworkCore;
using MVCVendasWeb.Models;

namespace MVCVendasWeb.Services
{
    public class DepartmentService
    {
        private readonly MVCVendasWebContext _context;

        public DepartmentService(MVCVendasWebContext context)
        {
            _context = context;
        }  

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Department.OrderBy(dp => dp.Name).ToListAsync();
        }

        public async Task<Department> GetAsync(int id)
        {
            return await _context.Department.FindAsync(id);
        }
    }
}
