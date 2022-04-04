using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class ProcedureBindingModel
    {
		public int? Id { get; set; }
		public int? ClientId { get; set; }
		public string ProcedureName { get; set; }
		public string FIO_Master { get; set; }
		public int Duration { get; set; }
		public decimal Price { get; set; }
	}
}
