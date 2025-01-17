﻿using MVCVendasWeb.Models;

namespace MVCVendasWeb.Services
{
    public class DepartmentService
    {
        private readonly MVCVendasWebContext _context;

        public DepartmentService(MVCVendasWebContext context)
        {
            _context = context;
        }  

        public List<Department> GetAll()
        {
            return _context.Department.OrderBy(dp => dp.Name).ToList();
        }

        public Department Get(int id)
        {
            return _context.Department.FirstOrDefault(dp => dp.Id == id);
        }
    }
}
