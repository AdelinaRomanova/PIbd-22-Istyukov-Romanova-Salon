using System;

namespace BeautySalonContracts.ViewModels
{
    public class ReportPurchaseCosmeticViewModel
    {
        public DateTime Date { get; set; }
        public string CosmeticName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalCost { get; set; }
        public int ClientId { get; set; }
    }
}
