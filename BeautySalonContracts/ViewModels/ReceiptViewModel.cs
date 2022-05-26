using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.ViewModels
{
    public class ReceiptViewModel
    {
        [DisplayName("Номер чека")]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [DisplayName("Общая стоимость")]
        public decimal TotalCost { get; set; }
        [DisplayName("Дата покупки")]
        public DateTime Date { get; set; }
        public Dictionary<int, (string, int)> ReceiptCosmetics { get; set; }
        public Dictionary<int, decimal> ReceiptPurchases { get; set; }
    }
}
