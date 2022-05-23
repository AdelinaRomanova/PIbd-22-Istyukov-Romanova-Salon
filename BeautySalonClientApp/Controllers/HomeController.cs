using BeautySalonClientApp.Models;
using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Purchase()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<ClientViewModel>>($"api/main/GetClientPurchaseList?clientId={Program.Client.Id}"));
        }

        [HttpGet]
        public IActionResult CreatePurchase()
        {
            ViewBag.Procedures = APIClient.GetRequest<List<ProcedureViewModel>>("api/client/GetProcedures");
            return View();
        }

        public void CreatePurchase(DateTime datepicker, int price, List<int> procedureId)
        {
            List<ProcedureViewModel> procedures = new List<ProcedureViewModel>();
            foreach (var procId in procedureId)
            {
                procedures.Add(APIClient.GetRequest<ProcedureViewModel>($"api/client/GetProcedure?procedureId={procId}"));
            }
            if (datepicker != DateTime.MinValue && price!=0 && procedures != null)
            {
                APIClient.PostRequest("api/client/CreateOrUpdateClient", new ClientBindingModel
                {
                    //ClientFIO = clientFIO,
                    //PassportData = passport,
                    //TelephoneNumber = telephone,
                    //DateVisit = DateTime.Now,
                    //ClientLoanPrograms = procedures.ToDictionary(x => x.Id, x => x.LoanProgramName),
                    //ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Client");
                return;
            }
            throw new Exception("Введите ФИО, паспортные данные и номер телефона");
        }
    }


}
