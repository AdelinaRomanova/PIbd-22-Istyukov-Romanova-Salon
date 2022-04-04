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
        public ReceiptLogic(IReceiptStorage receiptStorage)
        {
            _receiptStorage = receiptStorage;
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
    }
}
