using System.ComponentModel;

namespace BeautySalonContracts.ViewModels
{
    public class DataGridReceiptItemViewModel
    {
        public int Id { get; set; }

        [DisplayName("Косметика")]
        public string CosmeticName { get; set; }

        [DisplayName("Стоимость")]
        public decimal? Price { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
