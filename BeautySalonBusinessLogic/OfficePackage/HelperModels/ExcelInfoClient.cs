using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfoClient
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDistributionProcedureViewModel> DistributionProcedure { get; set; }
    }
}
