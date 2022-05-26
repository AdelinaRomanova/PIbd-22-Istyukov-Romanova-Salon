using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDatabaseImplement.Models
{
    public class Purchase
    {
		public int Id { get; set; }
		public int ClientId { get; set; }
		public int? ReceiptId { get; set; }

		[Required]
		public decimal Price { get; set; }
		
		[Required]
		public DateTime Date { get; set; }

		public virtual Receipt Receipt { get; set; }
		public virtual Client Client { get; set; }

		[ForeignKey("PurchaseId")]
		public virtual List<ProcedurePurchase> ProcedurePurchase { get; set; }
		[ForeignKey("PurchaseId")]
		public virtual List<PurchaseReceipt> PurchaseReceipts { get; set; }

	}
}
