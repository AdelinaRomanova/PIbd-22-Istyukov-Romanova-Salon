using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.ViewModels
{
    public class ReportDistributionProcedureViewModel
    {
        public DateTime Date { get; set; }
        public string ProcedureName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalCost { get; set; }
        public int EmployeeId { get; set; }
    }
}
