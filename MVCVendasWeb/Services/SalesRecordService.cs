using Microsoft.EntityFrameworkCore;
using MVCVendasWeb.Models;

namespace MVCVendasWeb.Services
{
    public class SalesRecordService
    {
        private readonly MVCVendasWebContext _context;

        public SalesRecordService(MVCVendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(sales => sales.Seller)
                .ThenInclude(seller => seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department?, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(sales => sales.Seller)
                .ThenInclude(seller => seller!.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller!.Department)
                .ToListAsync();
        }
    }
}
