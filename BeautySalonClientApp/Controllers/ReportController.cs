using BeautySalonClientApp.Models;
using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using BeautySalonClientApp;

namespace BankClerkApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ReportController(ILogger<ReportController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult ReportWordExcel()
        {            
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Procedures = APIClient.GetRequest<List<ProcedureViewModel>>($"api/client/GetClientProcedureList?clientId={Program.Client.Id}");
            return View();
        }

        [HttpPost]
        public IActionResult SavePurchaseListToWordFile(List<int> proceduresId)
        {
            //if (proceduresId != null)
            //{
            //    var model = new ReportClientBindingModel
            //    {
            //        Clients = new List<ClientViewModel>(),
            //        LoanPrograms = new List<LoanProgramViewModel>()
            //    };
            //    foreach (var clientId in proceduresId)
            //    {
            //        model.Clients.Add(APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}"));
            //    }
            //    model.FileName = @"..\BankClerkApp\wwwroot\ReportClientCurrency\ReportClientCurrencyDoc.doc";
            //    APIClerk.PostRequest("api/report/CreateReportClientCurrencyToWordFile", model);
            //    var fileName = "ReportClientCurrencyDoc.doc";
            //    var filePath = _environment.WebRootPath + @"\ReportClientCurrency\" + fileName;
            //    return PhysicalFile(filePath, "application/doc", fileName);
            //}
            throw new Exception("Выберите хотя бы одного клиента");
        }
      
    }
}
