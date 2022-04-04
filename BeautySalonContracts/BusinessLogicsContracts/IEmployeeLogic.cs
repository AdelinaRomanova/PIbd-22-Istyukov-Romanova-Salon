using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IEmployeeLogic
    {
        List<EmployeeViewModel> Read(EmployeeBindingModel model);
        void CreateOrUpdate(EmployeeBindingModel model);
        void Delete(EmployeeBindingModel model);
    }
}
