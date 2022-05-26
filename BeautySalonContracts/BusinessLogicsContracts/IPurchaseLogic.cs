using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IPurchaseLogic
    {
        List<PurchaseViewModel> Read(PurchaseBindingModel model);
        void CreateOrUpdate(PurchaseBindingModel model);
        void Delete(PurchaseBindingModel model);
        void AddPurcheses(AddPurchasesBindingModel model);
    }
}
