using System.ComponentModel;
using MVCVendasWeb.Models.Shared;

namespace MVCVendasWeb.Models
{
    public class Department
    {
        public Department() { }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        [DisplayName("Nome")]
        public string? Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = [];

        public void AddSeller(Seller seller)
        {
            if (seller != null)
                Sellers.Add(seller);
        }

        public void RemoveSeller(Seller seller)
        {
            if (seller != null)
                Sellers.Remove(seller);
        }

        public double TotalSalesAmount(DateTime startDate, DateTime tillDate)
        {
            Helper.ValidateSalesDates(startDate, tillDate);

            return Sellers.Sum(s => s.TotalSalesAmount(startDate, tillDate));
        }
    }
}
