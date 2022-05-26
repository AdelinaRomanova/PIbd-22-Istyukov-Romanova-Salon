using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonDatabaseImplement.Models
{
    public class PurchaseReceipt
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ReceiptId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
