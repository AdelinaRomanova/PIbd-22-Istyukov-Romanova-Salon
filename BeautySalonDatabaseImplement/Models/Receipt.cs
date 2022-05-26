using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDatabaseImplement.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
        
        [ForeignKey("ReceiptId")]
        public virtual List<Purchase> Purchases { get; set; }

        [ForeignKey("ReceiptId")]
        public virtual List<ReceiptCosmetic> ReceiptCosmetics { get; set; }
        [ForeignKey("ReceiptId")]
        public virtual List<PurchaseReceipt> ReceiptPurcheses { get; set; }
    }
}
