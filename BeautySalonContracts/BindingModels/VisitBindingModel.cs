using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class VisitBindingModel
    {
		public int? Id { get; set; }
		public int? ClientId { get; set; }
		public DateTime Date { get; set; }
		public Dictionary<int, string> VisitProcedures { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
	}
}
