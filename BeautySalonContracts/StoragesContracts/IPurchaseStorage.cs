using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IPurchaseStorage
    {
        List<PurchaseViewModel> GetFullList();

        List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model);

        PurchaseViewModel GetElement(PurchaseBindingModel model);

        void Insert(PurchaseBindingModel model);

        void Update(PurchaseBindingModel model);

        void Delete(PurchaseBindingModel model);
    }
}
