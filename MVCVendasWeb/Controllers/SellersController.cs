using Microsoft.AspNetCore.Mvc;

namespace MVCVendasWeb.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
