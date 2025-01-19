using MVCVendasWeb.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCVendasWeb.Models
{
    [Display(Name = "Registro de Vendas")]
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

        [DisplayName("Id da Venda")]
        public int Id { get; set; }

        [Display(Name = "Data da Venda")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DisplayName("Total")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }

        [Display(Name = "Vendedor")]
        public Seller? Seller { get; set; }
    }
}
