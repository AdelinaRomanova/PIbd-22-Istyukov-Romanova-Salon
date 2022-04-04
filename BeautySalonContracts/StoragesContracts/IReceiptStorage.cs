using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IReceiptStorage
    {
		List<ReceiptViewModel> GetFullList();
		List<ReceiptViewModel> GetFilteredList(ReceiptBindingModel model);
		ReceiptViewModel GetElement(ReceiptBindingModel model);
		void Insert(ReceiptBindingModel model);
		void Update(ReceiptBindingModel model);
		void Delete(ReceiptBindingModel model);
	}
}
