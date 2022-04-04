using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface ICosmeticLogic
    {
        List<CosmeticViewModel> Read(CosmeticBindingModel model);
        void CreateOrUpdate(CosmeticBindingModel model);
        void Delete(CosmeticBindingModel model);
    }
}
