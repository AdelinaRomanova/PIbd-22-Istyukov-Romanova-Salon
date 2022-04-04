using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfoEmployee
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int EmployeeId { get; set; }

        public List<ReportCosmeticsViewModel> Cosmetics { get; set; }
    }
}
