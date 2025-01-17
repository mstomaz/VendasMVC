using MVCVendasWeb.Models.Shared;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MVCVendasWeb.Models
{
    public class Seller
    {
        public Seller() { }

        public Seller(int id, string name, string email, DateOnly birthDate, double baseSalary, Department? department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public int Id { get; private set; }

        [DisplayName("Nome")]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        [DisplayName("Data de nascimento")]
        public DateOnly BirthDate { get; set; }

        [DisplayName("Salário base")]
        public double BaseSalary { get; set; }
        public Department? Department { get; set; }

        [DisplayName("Departamento")]
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public ICollection<SalesRecord> Sales { get; private set; } = [];

        public void AddSale(SalesRecord record)
        {
            if (record != null)
                Sales.Add(record);
        }

        public void RemoveSale(SalesRecord record)
        {
            if (record != null)
                Sales.Remove(record);
        }

        public double TotalSalesAmount(DateTime startDate, DateTime tillDate)
        {
            Helper.ValidateSalesDates(startDate, tillDate);

            return Sales.Where(s => s.Date >= startDate && s.Date <= tillDate) 
                .Sum(s => s.Amount);
        }
    }
}
