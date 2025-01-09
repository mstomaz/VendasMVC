using System.ComponentModel;

namespace MVCVendasWeb.Models
{
    public class Department
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name{ get; set; } = null!;
    }
}
