using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonBusinessLogic.BusinessLogics
{
    public class ReceiptLogic : IReceiptLogic
    {
        private readonly IReceiptStorage _receiptStorage;
        private readonly IPurchaseStorage _purchaseStorage;
        public ReceiptLogic(IReceiptStorage receiptStorage, IPurchaseStorage purchaseStorage)
        {
            _receiptStorage = receiptStorage;
            _purchaseStorage = purchaseStorage;
        }
        public List<ReceiptViewModel> Read(ReceiptBindingModel model)
        {
            if (model == null)
            {
                return _receiptStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ReceiptViewModel> { _receiptStorage.GetElement(model) };
            }
            return _receiptStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ReceiptBindingModel model)
        {
            var element = _receiptStorage.GetElement(new ReceiptBindingModel { Date = model.Date });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже пробит чек в данное время");
            }
            if (model.Id.HasValue)
            {
                _receiptStorage.Update(model);
            }
            else
            {
                _receiptStorage.Insert(model);
            }
        }
        public void Delete(ReceiptBindingModel model)
        {
            var element = _receiptStorage.GetElement(new ReceiptBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Чек не найден");
            }
            _receiptStorage.Delete(model);
        }

        public void AddPurchases(AddPurchasesBindingModel model)
        {
            var receipt = _receiptStorage.GetElement(new ReceiptBindingModel
            {
                Id = model.ReceiptId
            });

            if (receipt == null)
            {
                throw new Exception("Вклад не найден");
            }

            receipt.ReceiptPurchases.Clear();

            foreach (var purchaseId in model.PurchasesId)
            {
                var purchase = _purchaseStorage.GetElement(new PurchaseBindingModel
                {
                    Id = purchaseId
                });

                if (purchase == null)
                {
                    throw new Exception("Покупка не найдена");
                }

                receipt.ReceiptPurchases.Add(purchaseId, purchase.Price);
            }
            _receiptStorage.Update(new ReceiptBindingModel
            {
                Id = receipt.Id,
                Date = receipt.Date,
                TotalCost = receipt.TotalCost,
                ReceiptCosmetics = receipt.ReceiptCosmetics,
                EmployeeId = receipt.EmployeeId,
                ReceiptPurchases = receipt.ReceiptPurchases
            });
        }
    }
}
