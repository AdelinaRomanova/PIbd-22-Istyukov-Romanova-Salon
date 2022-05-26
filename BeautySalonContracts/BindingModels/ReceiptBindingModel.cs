using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class ReceiptBindingModel
    {
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<int, (string, int)> ReceiptCosmetics { get; set; }
        public Dictionary<int, decimal> ReceiptPurchases { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
