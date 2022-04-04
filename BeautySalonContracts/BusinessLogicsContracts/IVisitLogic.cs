using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IVisitLogic
    {
        List<VisitViewModel> Read(VisitBindingModel model);
        void CreateOrUpdate(VisitBindingModel model);
        void Delete(VisitBindingModel model);
        List<DateTime> GetPickDate(VisitBindingModel model);
    }
}
