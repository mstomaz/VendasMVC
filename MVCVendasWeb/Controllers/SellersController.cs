using Microsoft.AspNetCore.Mvc;
using MVCVendasWeb.Services;

namespace MVCVendasWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            return View(_sellerService.GetAll());
        }
    }
}
