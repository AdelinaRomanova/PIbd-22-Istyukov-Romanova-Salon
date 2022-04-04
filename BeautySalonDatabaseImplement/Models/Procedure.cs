using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BeautySalonDatabaseImplement.Models
{
    public class Procedure
    {
		public int Id { get; set; }
		public int ClientId { get; set; }

		[Required]
		public string ProcedureName { get; set; }

		[Required]
		public string FIO_Master { get; set; }

		[Required]
		public int Duration { get; set; }

		[Required]
		public decimal Price { get; set; }

		public virtual Client Client { get; set; }

		[ForeignKey("ProcedureId")]
		public virtual List<ProcedurePurchase> ProcedurePurchase { get; set; }

		[ForeignKey("ProcedureId")]
		public virtual List<ProcedureVisit> ProcedureVisit { get; set; }
	}
}
