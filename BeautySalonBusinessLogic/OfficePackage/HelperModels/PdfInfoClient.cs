using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfoClient
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportProceduresViewModel> Procedures { get; set; }
    }
}
