using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.StoragesContracts
{
    public interface ICosmeticStorage
    {
		List<CosmeticViewModel> GetFullList();
		List<CosmeticViewModel> GetFilteredList(CosmeticBindingModel model);
		CosmeticViewModel GetElement(CosmeticBindingModel model);
		void Insert(CosmeticBindingModel model);
		void Update(CosmeticBindingModel model);
		void Delete(CosmeticBindingModel model);
	}
}
