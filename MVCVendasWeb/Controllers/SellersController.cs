using Microsoft.AspNetCore.Mvc;
using MVCVendasWeb.Services;
using MVCVendasWeb.Models;
using MVCVendasWeb.Models.ViewModels;
using MVCVendasWeb.Services.Exceptions;
using System.Diagnostics;

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

        public async Task<IActionResult> Index()
        {
            return View(await _sellerService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.GetAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
                return View(seller);

            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { Message = "Id não fornecido." });

            var seller = await _sellerService.GetAsync(id.Value);

            if (seller == null)
                return RedirectToAction(nameof(Error), new { Message = "Vendedor não encontrado." });

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var seller = await _sellerService.GetAsync(id);

                var department = await _departmentService.GetAsync(seller!.DepartmentId);
                department.RemoveSeller(seller);

                await _sellerService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { ex.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { Message = "Id não fornecido." });

            var seller = await _sellerService.GetAsync(id.Value);
            if (seller is null)
                return RedirectToAction(nameof(Error), new { Message = "Vendedor não encontrado." });

            return View(seller);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { Message = "Id não fornecido." });

            var obj = await _sellerService.GetAsync(id.Value);

            if (obj is null)
                return RedirectToAction(nameof(Error), new { Message = "Vendedor não encontrado" });

            List<Department> departments = await _departmentService.GetAllAsync();

            SellerFormViewModel viewModel = new()
            {
                Seller = obj,
                Departments = departments
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(Prefix = "Seller")] Seller obj)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.GetAllAsync();
                var viewModel = new SellerFormViewModel
                {
                    Departments = departments,
                    Seller = obj
                };

                return View(obj);
            }

            if (id != obj.Id)
                return RedirectToAction(nameof(Error), new { Message = "IDs não correspondem." });

            try
            {
                await _sellerService.UpdateAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Error), new { ex.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
