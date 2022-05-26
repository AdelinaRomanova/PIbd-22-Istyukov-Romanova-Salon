using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BeautySalonBusinessLogic.BusinessLogics
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientStorage _clientStorage;

        private readonly int _emailMaxLength = 50;
        private readonly int _passwordMaxLength = 30;
        private readonly int _passwordMinLength = 10;
        public ClientLogic(IClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClientViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel { Email = model.Email });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть клиент с такой почтой");
            }
            if (model.Email.Length > _emailMaxLength || !Regex.IsMatch(model.Email, @"([a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+)"))
            {
                throw new Exception($"В качестве логина должна быть указана почта и иметь длинну не более {_emailMaxLength} символов");
            }
            if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength
                || !Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"Пароль длиной от {_passwordMinLength} до { _passwordMaxLength } должен состоять из цифр, букв и небуквенных символов");
            }
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }
        public void Delete(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            _clientStorage.Delete(model);
        }
    }
}
