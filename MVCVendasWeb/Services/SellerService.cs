using Microsoft.EntityFrameworkCore;
using MVCVendasWeb.Models;

namespace MVCVendasWeb.Services
{
    public class SellerService
    {
        private readonly MVCVendasWebContext _context;

        public SellerService(MVCVendasWebContext context)
        {
            _context = context;
        }

        public IEnumerable<Seller> GetAll()
        {
            return _context.Seller.ToList();
        }

        public async Task Insert(Seller obj)
        {
            ArgumentNullException.ThrowIfNull(obj, nameof(obj));

            obj.Department = await _context.Department.FirstOrDefaultAsync();

            if (obj.Department is null)
                throw new InvalidOperationException("Departamento nao encontrado.");

            _context.Seller.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
