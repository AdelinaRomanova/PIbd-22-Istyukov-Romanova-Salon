using System.ComponentModel;

namespace BeautySalonContracts.ViewModels
{
    public class DataGridPurchaseListItemViewModel
    {
        public int Id { get; set; }

        [DisplayName("Косметика")]
        public string CosmeticName { get; set; }
    }
}
