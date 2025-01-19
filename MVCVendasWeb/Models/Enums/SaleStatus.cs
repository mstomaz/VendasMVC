using System.ComponentModel.DataAnnotations;

namespace MVCVendasWeb.Models.Enums
{
    public enum SaleStatus
    {
        [Display(Name  = "Pendente")]
        Pending,
        [Display(Name = "Faturado")]
        Billed,
        [Display(Name = "Cancelado")]
        Canceled
    }
}
