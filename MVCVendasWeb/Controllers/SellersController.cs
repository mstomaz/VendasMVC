using Microsoft.AspNetCore.Mvc;
using MVCVendasWeb.Services;
using MVCVendasWeb.Models;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            await _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
