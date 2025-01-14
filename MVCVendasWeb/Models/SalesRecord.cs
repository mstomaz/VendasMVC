﻿using MVCVendasWeb.Models.Enums;

namespace MVCVendasWeb.Models
{
    public class SalesRecord
    {
        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public double Amount { get; private set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; private set; } = null!;
    }
}
