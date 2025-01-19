using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<IEnumerable<Seller>> GetAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            ArgumentNullException.ThrowIfNull(obj, nameof(obj));

            _context.Seller.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller?> GetAsync(int id)
        {
            return await _context.Seller
                .Include(seller => seller.Department)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            if (await _context.Seller.FindAsync(id) is null)
                return;

            try
            {
                _context.Seller.Remove(await GetAsync(id));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message, ex);
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            if (!await _context.Seller.AnyAsync(x => x.Id == obj.Id))
                throw new NotFoundException("Vendedor nao encontrado.");

            try
            {
                _context.Update(obj);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
            await _context.SaveChangesAsync();
        }

    }
}
