﻿using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IClientStorage
    {
		List<ClientViewModel> GetFullList();
		List<ClientViewModel> GetFilteredList(ClientBindingModel model);
		ClientViewModel GetElement(ClientBindingModel model);
		void Insert(ClientBindingModel model);
		void Update(ClientBindingModel model);
		void Delete(ClientBindingModel model);
	}
}
