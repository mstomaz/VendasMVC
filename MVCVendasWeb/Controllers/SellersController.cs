using Microsoft.AspNetCore.Mvc;
using MVCVendasWeb.Services;
using MVCVendasWeb.Models;
using MVCVendasWeb.Models.ViewModels;
using MVCVendasWeb.Services.Exceptions;

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

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var seller = _sellerService.Get(id.Value);
            if (seller is null)
                return NotFound();

            return View(seller);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.Get(id.Value);

            if (obj is null)
                return NotFound();

            List<Department> departments = _departmentService.GetAll();

            SellerFormViewModel viewModel = new SellerFormViewModel
            {
                Seller = obj,
                Departments = departments
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind(Prefix = "Seller")] Seller obj)
        {
            if (id != obj.Id)
                return BadRequest();

            try
            {
                _sellerService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            catch (DbConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
