using MVCVendasWeb.Models.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' não pode ser vazio.")]
        [DisplayName("Nome")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} letras.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo '{0}' não pode ser vazio.")]
        [EmailAddress(ErrorMessage = "{0} inválido.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo '{0}' não pode ser vazio.")]
        [DisplayName("Data de nascimento")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "O campo '{0}' não pode ser vazio.")]
        [Range(600, 50000, ErrorMessage = "O {0} deve estar entre {1} e {2}.")]
        [DisplayName("Salário base")]
        [DataType(DataType.Currency)]
        public double? BaseSalary { get; set; }

        [Display(Name = "Departamento")]
        public Department? Department { get; set; }

        [DisplayName("Departamento")]
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public ICollection<SalesRecord>? Sales { get; set; } = [];

        public void AddSale(SalesRecord record)
        {
            if (record != null)
                Sales!.Add(record);
        }

        public void RemoveSale(SalesRecord record)
        {
            if (record != null)
                Sales!.Remove(record);
        }

        public double TotalSalesAmount(DateTime startDate, DateTime tillDate)
        {
            Helper.ValidateSalesDates(startDate, tillDate);

            return Sales.Where(s => s.Date >= startDate && s.Date <= tillDate)
                .DefaultIfEmpty()
                .Sum(s => s!.Amount);
        }
    }
}
