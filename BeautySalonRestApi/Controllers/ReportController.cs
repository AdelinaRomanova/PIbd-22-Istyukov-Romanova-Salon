using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController
    {
        private readonly IReportClientLogic _reportLogic;
        private readonly IProcedureLogic _procedureLogic;
        public ReportController(IReportClientLogic reportLogic, IProcedureLogic procedureLogic)
        {
            _reportLogic = reportLogic;
            _procedureLogic = procedureLogic;
        }

        [HttpPost]
        public void SavePurchaseListToWordFile(ReportClientBindingModel model) => _reportLogic.SavePurchaseListToWordFile(model);

        [HttpPost]
        public void SavePurchaseListToExcelFile(ReportClientBindingModel model) => _reportLogic.SavePurchaseListToExcelFile(model);

        [HttpPost]
        public void SaveProceduresToPdfFile(ReportClientBindingModel model) => _reportLogic.SaveProceduresToPdfFile(model);

        //[HttpGet]
        //public ReportBindingModel GetClientsForReport(int ClerkId)
        //{
        //    return new ReportBindingModel
        //    {
        //        ClerkId = ClerkId,
        //        Clients = _procedureLogic.Read(new ClientBindingModel { ClerkId = ClerkId })
        //    };
        //}

    }
}
