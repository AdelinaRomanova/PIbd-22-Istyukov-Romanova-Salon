using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IEmployeeStorage
    {
		List<EmployeeViewModel> GetFullList();
		List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model);
		EmployeeViewModel GetElement(EmployeeBindingModel model);
		void Insert(EmployeeBindingModel model);
		void Update(EmployeeBindingModel model);
		void Delete(EmployeeBindingModel model);
	}
}
