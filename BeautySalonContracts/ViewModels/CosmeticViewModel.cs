using System.ComponentModel;

namespace BeautySalonContracts.ViewModels
{
    public class CosmeticViewModel
    {
        public int? Id { get; set; }

        public int EmployeeId { get; set; }
        [DisplayName("Название косметики")]
        public string CosmeticName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
