using BeautySalonContracts.BindingModels;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using BeautySalonDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
		public List<ClientViewModel> GetFullList()
		{
			using var context = new BeautySalonDatabase();
			return context.Clients.Select(CreateModel).ToList();
		}
		public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			using var context = new BeautySalonDatabase();
			return context.Clients
				.Include(x => x.Procedure)
				.Include(x => x.Purchase)
				.Include(x => x.Visit)
				.Where(rec => rec.Email.Contains(model.Email) && rec.Password == model.Password)
				.Select(CreateModel).ToList();
		}
		public ClientViewModel GetElement(ClientBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			using var context = new BeautySalonDatabase();
			var client = context.Clients
				.Include(x => x.Procedure)
				.Include(x => x.Purchase)
				.Include(x => x.Visit)
				.FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id);
			return client != null ? CreateModel(client) : null;
		}
		public void Insert(ClientBindingModel model)
		{
			using var context = new BeautySalonDatabase();
			context.Clients.Add(CreateModel(model, new Client()));
			context.SaveChanges();
		}
		public void Update(ClientBindingModel model)
		{
			using var context = new BeautySalonDatabase();
			var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Клиент не найден");
			}
			CreateModel(model, element);
			context.SaveChanges();
		}
		public void Delete(ClientBindingModel model)
		{
			using var context = new BeautySalonDatabase();
			Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Clients.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Клиент не найден");
			}
		}
		private static Client CreateModel(ClientBindingModel model, Client client)
		{
			client.ClientName = model.ClientName;
			client.ClientSurname = model.ClientSurname;
			client.Patronymic = model.Patronymic;
			client.Email = model.Email;
			client.Password = model.Password;
			client.Phone = model.Phone;
			return client;
		}
		private static ClientViewModel CreateModel(Client client)
		{
			return new ClientViewModel
			{
				Id = client.Id,
				ClientName = client.ClientName,
				ClientSurname = client.ClientSurname,
				Patronymic = client.Patronymic,
				Email = client.Email,
				Password = client.Password,
				Phone = client.Phone
			};
		}
	}
}
