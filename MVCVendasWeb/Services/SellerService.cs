﻿using Microsoft.EntityFrameworkCore;
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
    }
}