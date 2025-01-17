using Microsoft.AspNetCore.Mvc;
using MVCVendasWeb.Services;
using MVCVendasWeb.Models;
using MVCVendasWeb.Models.ViewModels;

namespace MVCVendasWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View(_sellerService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.GetAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var seller = _sellerService.Get(id.Value);

            if (seller == null)
                return NotFound();

            seller.Department = _departmentService.Get(seller.DepartmentId);

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var seller = _sellerService.Get(id);

            var department = _departmentService.Get(seller!.DepartmentId);
            department.RemoveSeller(seller);

            _sellerService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
