using Microsoft.EntityFrameworkCore;
using MVCVendasWeb.Models;
using MVCVendasWeb.Services.Exceptions;

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

        public void Insert(Seller obj)
        {
            ArgumentNullException.ThrowIfNull(obj, nameof(obj));

            _context.Seller.Add(obj);
            _context.SaveChanges();
        }

        public Seller? Get(int id)
        {
            return _context.Seller
                .Include(seller => seller.Department)
                .FirstOrDefault(s => s.Id == id);
        }

        public void Delete(int id)
        {
            if (_context.Seller.Find(id) is null)
                return;

            _context.Seller.Remove(Get(id)!);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
                throw new NotFoundException("Vendedor nao encontrado.");

            try
            {
                _context.Update(obj);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
            _context.SaveChanges();
        }

    }
}
