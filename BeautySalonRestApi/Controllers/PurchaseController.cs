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
    public class PurchaseController
    {
        private readonly IPurchaseLogic _purchaseLogic;
        private readonly IProcedureLogic _procedureLogic;

        public PurchaseController(IPurchaseLogic purchaseLogic, IProcedureLogic procedureLogic)
        {
            _purchaseLogic = purchaseLogic;
            _procedureLogic = procedureLogic;
        }

        [HttpGet]
        public List<PurchaseViewModel> GetPurchaseList() => _purchaseLogic.Read(null)?.ToList();
        [HttpGet]
        public List<ProcedureViewModel> GetProcedureList() => _procedureLogic.Read(null)?.ToList();

        [HttpGet]
        public ProcedureViewModel GetProcedure(int procedureId) => _procedureLogic.Read(new ProcedureBindingModel { Id = procedureId })?[0];

        [HttpGet]
        public PurchaseViewModel GetPurchase(int purchaseId) => _purchaseLogic.Read(new PurchaseBindingModel { Id = purchaseId })?[0];

        [HttpPost]
        public void CreateOrUpdatePurchase(PurchaseBindingModel model) => _purchaseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeletePurchase(PurchaseBindingModel model) => _purchaseLogic.Delete(model);
    }
}
