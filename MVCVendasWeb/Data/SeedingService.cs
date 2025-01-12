using MVCVendasWeb.Models;
using MVCVendasWeb.Models.Enums;

namespace MVCVendasWeb.Data
{
    public class SeedingService
    {
        private readonly MVCVendasWebContext _context;

        public SeedingService(MVCVendasWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() || 
                _context.SalesRecord.Any())
            {
                return;
            }

            Department dpComputers = new(1, "Computadores");
            Department dpElectronics = new(2, "Eletrônicos");
            Department dpTools = new(3, "Ferramentas");

            Seller s1 = new(1, "Roberto", "Rb101@gmail.com", new(1987, 5, 21), 2500.0, dpTools);
            Seller s2 = new(2, "Ana", "analu@gmail.com", new(1999, 7, 8), 1861.0, dpElectronics);
            Seller s3 = new(3, "Mauro", "mst915@gmail.com", new(1982, 1, 25), 3200.0, dpComputers);

            SalesRecord r1 = new(1, new DateTime(2025, 1, 10), 15000, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2024, 09, 4), 7000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2024, 09, 13), 4000.0, SaleStatus.Canceled, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2024, 09, 1), 8000.0, SaleStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2024, 09, 21), 3000.0, SaleStatus.Billed, s3);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2024, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2024, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2024, 09, 11), 4000.0, SaleStatus.Billed, s3);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2024, 09, 14), 11000.0, SaleStatus.Pending, s1);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2024, 09, 7), 9000.0, SaleStatus.Billed, s1);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2024, 09, 13), 6000.0, SaleStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2024, 09, 25), 7000.0, SaleStatus.Pending, s3);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2024, 09, 29), 10000.0, SaleStatus.Billed, s3);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2024, 09, 4), 3000.0, SaleStatus.Billed, s2);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2024, 09, 12), 4000.0, SaleStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2024, 10, 5), 2000.0, SaleStatus.Billed, s3);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2024, 10, 1), 12000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(dpComputers, dpElectronics, dpTools);
            _context.Seller.AddRange(s1, s2, s3);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7,
                r8, r9, r10, r11, r12, r13, r14, r15, r16, r17);

            _context.SaveChanges();
        }
    }
}
