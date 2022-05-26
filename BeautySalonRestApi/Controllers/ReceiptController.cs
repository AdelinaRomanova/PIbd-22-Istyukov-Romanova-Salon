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
    public class ReceiptController
    {
        private readonly IReceiptLogic _receiptLogic;

        public ReceiptController(IReceiptLogic receiptLogic)
        {
            _receiptLogic = receiptLogic;
        }

        [HttpGet]
        public List<ReceiptViewModel> GetReceiptList() => _receiptLogic.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateReceipt(ReceiptBindingModel model) => _receiptLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteReceipt(ReceiptBindingModel model) => _receiptLogic.Delete(model);

        [HttpPost]
        public void AddReceiptPurchases(AddPurchasesBindingModel model) => _receiptLogic.AddPurchases(model);
    }
}
