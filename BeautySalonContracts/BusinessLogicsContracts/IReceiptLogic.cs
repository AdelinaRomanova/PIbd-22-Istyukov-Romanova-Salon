using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IReceiptLogic
    {
        List<ReceiptViewModel> Read(ReceiptBindingModel model);
        void CreateOrUpdate(ReceiptBindingModel model);
        void Delete(ReceiptBindingModel model);
    }
}
