using Microsoft.AspNetCore.Mvc;
using MVCVendasWeb.Models;

namespace MVCVendasWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = [];
            departments.AddRange(
                [
                    new Department() { Id=1, Name="Eletrônicos" },
                    new Department() { Id=2, Name="Moda" }
                ]);

            return View(departments);
        }
    }
}
