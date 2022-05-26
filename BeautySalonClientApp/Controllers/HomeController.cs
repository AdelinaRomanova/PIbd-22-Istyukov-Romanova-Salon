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
using System.Threading.Tasks;

namespace BeautySalonClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult IndexProcedure()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<ProcedureViewModel>>($"api/main/GetProcedureList?clientId={Program.Client.Id}"));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Client);
        }

        [HttpPost]
        public void Privacy(string clientName, string clientSurname, string patronymic, string email, string password, string phone )
        {
            if (!string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(clientSurname) && !string.IsNullOrEmpty(patronymic) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(phone))
            {
                APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                {
                    Id = Program.Client.Id,
                    ClientName = clientName,
                    ClientSurname = clientSurname,
                    Patronymic = patronymic,
                    Email = email,
                    Password = password,
                    Phone = phone
                });
                Program.Client.ClientName = clientName;
                Program.Client.ClientSurname = clientSurname;
                Program.Client.Patronymic = patronymic;
                Program.Client.Email = email;
                Program.Client.Password = password;
                Program.Client.Phone = phone;
                Response.Redirect("IndexProcedure");
                return;
            }
            throw new Exception("Введите логин, пароль, ФИО и номер телефона");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                Program.Client = APIClient.GetRequest<ClientViewModel>($"api/Client/login?login={email}&password={password}");

                if (Program.Client == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("IndexProcedure");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string clientName, string clientSurname, string patronymic, string email, string password, string phone)
        {
            if (!string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(clientSurname) && !string.IsNullOrEmpty(patronymic) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(phone))
            {
                APIClient.PostRequest("api/client/register", new ClientBindingModel
                {
                    ClientName = clientName,
                    ClientSurname = clientSurname,
                    Patronymic = patronymic,
                    Email = email,
                    Password = password,
                    Phone = phone
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        
        // --------------PROCEDURES-----------------

        [HttpGet]
        public IActionResult CreateProcedure()
        {
            ViewBag.Procedures = APIClient.GetRequest<List<ProcedureViewModel>>("api/main/GetProcedureList");
            return View();
        }

        public void CreateProcedure(string procedureName, string fioMaster, int duration, decimal price)
        {
            if (!string.IsNullOrEmpty(procedureName) && !string.IsNullOrEmpty(fioMaster) && !string.IsNullOrEmpty(procedureName) && duration != 0 && price != 0)
            {
                APIClient.PostRequest("api/main/CreateProcedure", new ProcedureBindingModel
                {
                    ClientId = Program.Client.Id,
                    ProcedureName = procedureName,
                    FIO_Master = fioMaster,
                    Duration = duration,
                    Price = price

                });
                Response.Redirect("IndexProcedure");
                return;
            }
            throw new Exception("Заполните всё поля!");
        }

        [HttpGet]
        public IActionResult UpdateProcedure(int Id)
        {
            var procedure = APIClient.GetRequest<ProcedureViewModel>($"api/main/GetProcedure?id={Id}");
            return View(procedure);
        }

        [HttpPost]
        public void UpdateProcedure(string procedureName, string fioMaster, int duration, decimal price, ProcedureViewModel model)
        {
            if (string.IsNullOrEmpty(procedureName) || string.IsNullOrEmpty(fioMaster) || string.IsNullOrEmpty(procedureName) || duration == 0 || price == 0)
            {
                return;
            }
            APIClient.PostRequest("api/main/CreateProcedure", new ProcedureBindingModel
            {
                Id = model.Id,
                ClientId = Program.Client.Id,
                ProcedureName = procedureName,
                FIO_Master = fioMaster,
                Duration = duration,
                Price = price
            });
            Response.Redirect("../IndexProcedure");
        }

        [HttpGet]
        public void DeleteProcedure(int Id)
        {
            APIClient.PostRequest($"api/main/DeleteProcedure", new ProcedureBindingModel
            {
                Id = Id
            });
            Response.Redirect("../IndexProcedure");
        }

        // --------------PURCHASES-----------------
        public IActionResult Purchase()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<PurchaseViewModel>>($"api/client/GetClientPurchaseList?clientId={Program.Client.Id}"));
        }

        [HttpGet]
        public IActionResult PurchaseCreate()
        {
            ViewBag.Procedures = new MultiSelectList(APIClient.GetRequest<List<ProcedureViewModel>>($"api/purchase/GetProcedureList"),
                "Id", "ProcedureName", "Price");
            return View(new PurchaseViewModel());
        }

        [HttpPost]
        public void PurchaseCreate(DateTime datepicker,[Bind("ProceduresId", "ProcedureName")] PurchaseViewModel model)
        {
            List<ProcedureViewModel> procedures = model.ProceduresId.
                Select(rec => APIClient.GetRequest<ProcedureViewModel>($"api/purchase/GetProcedure?procedureId={rec}")).ToList();
            if (datepicker != DateTime.MinValue && procedures != null)
            {
                APIClient.PostRequest("api/purchase/CreateOrUpdatePurchase", new PurchaseBindingModel
                {
                    Price = procedures.Sum(rec => rec.Price),
                    Date = datepicker,
                    PurchaseProcedures = procedures.ToDictionary(rec=>(rec.Id),(rec=>(rec.ProcedureName,rec.Price))),
                    ClientId = Program.Client.Id
                });
                Response.Redirect("Purchase");
                return;
            }
        }

        [HttpGet]
        public IActionResult PurchaseUpdate(int purchaseId)
        {
            ViewBag.Purchase = APIClient.GetRequest<PurchaseViewModel>($"api/purchase/GetPurchase?purchaseId={purchaseId}");
            ViewBag.Procedures = APIClient.GetRequest<List<ProcedureViewModel>>("api/purchase/GetProcedureList");
            var purchase = APIClient.GetRequest<PurchaseViewModel> ($"api/purchase/GetPurchase?purchaseId={purchaseId}");
            var Receipts = APIClient.GetRequest<List<ReceiptViewModel>>("api/receipt/GetReceiptList");
            var purchaseReceipts = new List<ReceiptViewModel>();
            foreach (var res in Receipts)
            {
                if (res.ReceiptPurchases.ContainsKey(purchaseId))
                {
                    purchaseReceipts.Add(res);
                }
            }
            ViewBag.PurchaseReceipts = purchaseReceipts;
            return View(purchase);
        }

        [HttpPost]
        public void PurchaseUpdate(int purchaseId, DateTime datepicker, List<int> proceduresId)
        {
            if (datepicker != DateTime.MinValue && proceduresId != null)
            {
                var purchase = APIClient.GetRequest<PurchaseViewModel>($"api/purchase/GetPurchase?purchaseId={purchaseId}");
                if (purchase == null)
                {
                    return;
                }
                List<ProcedureViewModel> procedures = new List<ProcedureViewModel>();
                foreach (var procedureId in proceduresId)
                {
                    procedures.Add(APIClient.GetRequest<ProcedureViewModel>($"api/purchase/GetProcedure?procedureId={procedureId}"));
                }
                APIClient.PostRequest("api/purchase/CreateOrUpdatePurchase", new PurchaseBindingModel
                {
                    Id = purchase.Id,
                    Price = procedures.Sum(rec => rec.Price),
                    Date = datepicker,
                    PurchaseProcedures = procedures.ToDictionary(rec => (rec.Id), (rec => (rec.ProcedureName, rec.Price))),
                    ClientId = Program.Client.Id
                });
                Response.Redirect("Purchase");
                return;
            }
            throw new Exception("Введите дату и выберите процедуры");
            
        }

        [HttpGet]
        public void PurchaseDelete(int purchaseId)
        {
            var purchase = APIClient.GetRequest<PurchaseViewModel>($"api/purchase/GetPurchase?purchaseId={purchaseId}");
            APIClient.PostRequest("api/purchase/DeletePurchase", purchase);
            Response.Redirect("Purchase");
        }

        // --------------VISIT-----------------
        public IActionResult Visit()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<VisitViewModel>>($"api/client/GetClientVisitList?clientId={Program.Client.Id}"));
        }

        [HttpGet]
        public IActionResult VisitCreate()
        {
            ViewBag.Procedures = new MultiSelectList(APIClient.GetRequest<List<ProcedureViewModel>>($"api/visit/GetProcedureList"),
                "Id", "ProcedureName", "Price");
            return View(new VisitViewModel());
        }

        [HttpPost]
        public void VisitCreate(DateTime datepicker, [Bind("ProceduresId", "ProcedureName")] PurchaseViewModel model)
        {
            List<ProcedureViewModel> procedures = model.ProceduresId.
                Select(rec => APIClient.GetRequest<ProcedureViewModel>($"api/visit/GetProcedure?procedureId={rec}")).ToList();
            if (datepicker != DateTime.MinValue && procedures != null)
            {
                APIClient.PostRequest("api/visit/CreateOrUpdateVisit", new VisitBindingModel
                {
                    Date = datepicker,
                    VisitProcedures = procedures.ToDictionary(rec => rec.Id, rec => rec.ProcedureName),
                    ClientId = Program.Client.Id
                });
                Response.Redirect("Visit");
                return;
            }
        }
        [HttpGet]
        public IActionResult VisitUpdate(int visitId)
        {
            ViewBag.Visit = APIClient.GetRequest<VisitViewModel>($"api/visit/GetVisit?visitId={visitId}");
            ViewBag.Procedures = APIClient.GetRequest<List<ProcedureViewModel>>("api/visit/GetProcedureList");
            var visit = APIClient.GetRequest<VisitViewModel>($"api/visit/GetVisit?visitId={visitId}");
            return View(visit);
        }

        [HttpPost]
        public void VisitUpdate(int visitId, DateTime datepicker, List<int> proceduresId)
        {
            if (datepicker != DateTime.MinValue && proceduresId != null)
            {
                var visit = APIClient.GetRequest<VisitViewModel>($"api/visit/GetVisit?visitId={visitId}");
                if (visit == null)
                {
                    return;
                }
                List<ProcedureViewModel> procedures = new List<ProcedureViewModel>();
                foreach (var procedureId in proceduresId)
                {
                    procedures.Add(APIClient.GetRequest<ProcedureViewModel>($"api/visit/GetProcedure?procedureId={procedureId}"));
                }
                APIClient.PostRequest("api/visit/CreateOrUpdateVisit", new VisitBindingModel
                {
                    Id = visit.Id,
                    Date = datepicker,
                    VisitProcedures = procedures.ToDictionary(rec => rec.Id, rec => rec.ProcedureName),
                    ClientId = Program.Client.Id
                });
                Response.Redirect("Visit");
                return;
            }
            throw new Exception("Введите дату и выберите процедуры");

        }
        [HttpGet]
        public void VisitDelete(int visitId)
        {
            var visit = APIClient.GetRequest<VisitViewModel>($"api/visit/GetVisit?visitId={visitId}");
            APIClient.PostRequest("api/visit/DeleteVisit", visit);
            Response.Redirect("Visit");
        }

        // --------------RECEIPT-----------------

        [HttpGet]
        public IActionResult AddReceiptPurchases()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Receipts = APIClient.GetRequest<List<ReceiptViewModel>>("api/receipt/GetReceiptList");
            ViewBag.Purchases = APIClient.GetRequest<List<PurchaseViewModel>>($"api/client/GetClientPurchaseList?clientId={Program.Client.Id}");
            return View();
        }

        [HttpPost]
        public void AddReceiptPurchases(int receiptId, List<int> purchesesId)
        {
            if (receiptId != 0 && purchesesId != null)
            {
                APIClient.PostRequest("api/receipt/AddReceiptPurchases", new AddPurchasesBindingModel
                {
                    ReceiptId = receiptId,
                    PurchasesId = purchesesId
                });
                Response.Redirect("Purchase");
                return;
            }
            throw new Exception("Выберите вклад и клиентов");
        }
    }


}
