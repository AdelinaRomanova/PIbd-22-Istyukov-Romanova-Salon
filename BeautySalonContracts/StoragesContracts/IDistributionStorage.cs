using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IDistributionStorage
    {
		List<DistributionViewModel> GetFullList();
		List<DistributionViewModel> GetFilteredList(DistributionBindingModel model);
		DistributionViewModel GetElement(DistributionBindingModel model);
		void Insert(DistributionBindingModel model);
		void Update(DistributionBindingModel model);
		void Delete(DistributionBindingModel model);
	}
}
