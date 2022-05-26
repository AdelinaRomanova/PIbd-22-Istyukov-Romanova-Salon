using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BeautySalonRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _logic;
        private readonly IPurchaseLogic _purchaseLogic;
        private readonly IVisitLogic _visitLogic;
        private readonly IProcedureLogic _procedureLogic;
        public ClientController(IClientLogic logic, IPurchaseLogic purchaseLogic, IVisitLogic visitLogic, IProcedureLogic procedureLogic)
        {
            _logic = logic;
            _purchaseLogic = purchaseLogic;
            _visitLogic = visitLogic;
            _procedureLogic = procedureLogic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password)
        {
            var list = _logic.Read(new ClientBindingModel
            {
                Email = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            _logic.CreateOrUpdate(model);
        }

        [HttpGet]
        public List<PurchaseViewModel> GetClientPurchaseList(int clientId) => _purchaseLogic.Read(new PurchaseBindingModel { ClientId = clientId });
        [HttpGet]
        public List<ProcedureViewModel> GetClientProcedureList(int clientId) => _procedureLogic.Read(new ProcedureBindingModel { ClientId = clientId });

        [HttpGet]
        public List<VisitViewModel> GetClientVisitList(int clientId) => _visitLogic.Read(new VisitBindingModel { ClientId = clientId });

        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }

}
