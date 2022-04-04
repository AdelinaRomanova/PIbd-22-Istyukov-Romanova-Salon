using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IProcedureLogic
    {
        List<ProcedureViewModel> Read(ProcedureBindingModel model);
        void CreateOrUpdate(ProcedureBindingModel model);
        void Delete(ProcedureBindingModel model);
    }
}
