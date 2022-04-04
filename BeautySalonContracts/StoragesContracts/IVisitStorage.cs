using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IVisitStorage
    {
        List<VisitViewModel> GetFullList();
        List<VisitViewModel> GetFilteredList(VisitBindingModel model);
        VisitViewModel GetElement(VisitBindingModel model);
        void Insert(VisitBindingModel model);
        void Update(VisitBindingModel model);
        void Delete(VisitBindingModel model);
    }
}
