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
    public class CosmeticStorage : ICosmeticStorage
    {
		public List<CosmeticViewModel> GetFullList()
		{
			using var context = new BeautySalonDatabase();
			return context.Cosmetics
				.Include(rec => rec.Employee)
				.Select(rec => new CosmeticViewModel
				{
					Id = rec.Id,
					CosmeticName = rec.CosmeticName,
					Price = rec.Price,
					EmployeeId = rec.EmployeeId
				})
				.ToList();
		}
		public List<CosmeticViewModel> GetFilteredList(CosmeticBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			using var context = new BeautySalonDatabase();
			return context.Cosmetics
				 .Include(rec => rec.Employee)
				.Where(rec => rec.EmployeeId == model.EmployeeId || rec.CosmeticName.Contains(model.CosmeticName))
				.Select(rec => new CosmeticViewModel
				{
					Id = rec.Id,
					CosmeticName = rec.CosmeticName,
					Price = rec.Price,
					EmployeeId = rec.EmployeeId
				})
				.ToList();
		}
		public CosmeticViewModel GetElement(CosmeticBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			using var context = new BeautySalonDatabase();
			var cosmetic = context.Cosmetics
				.Include(rec => rec.Employee)
				.FirstOrDefault(rec => rec.CosmeticName == model.CosmeticName || rec.Id == model.Id);
			return cosmetic != null ?
				new CosmeticViewModel
				{
					Id = cosmetic.Id,
					CosmeticName = cosmetic.CosmeticName,
					Price = cosmetic.Price,
					EmployeeId = cosmetic.EmployeeId
				} :
				null;
		}
		public void Insert(CosmeticBindingModel model)
		{
			using var context = new BeautySalonDatabase();
			context.Cosmetics.Add(CreateModel(model, new Cosmetic()));
			context.SaveChanges();
		}
		public void Update(CosmeticBindingModel model)
		{
			using var context = new BeautySalonDatabase();
			var element = context.Cosmetics.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Косметика не найдена");
			}
			CreateModel(model, element);
			context.SaveChanges();
		}
		public void Delete(CosmeticBindingModel model)
		{
			using var context = new BeautySalonDatabase();
			Cosmetic element = context.Cosmetics.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Cosmetics.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Косметика не найдена");
			}
		}
		private static Cosmetic CreateModel(CosmeticBindingModel model, Cosmetic cosmetic)
		{
			cosmetic.CosmeticName = model.CosmeticName;
			cosmetic.Price = model.Price;
			cosmetic.EmployeeId = (int)model.EmployeeId;
			return cosmetic;
		}
		private Cosmetic CreateModel(Cosmetic cosmetic, CosmeticBindingModel model)
		{
			cosmetic.CosmeticName = model.CosmeticName;
			cosmetic.Price = model.Price;
			cosmetic.EmployeeId = (int)model.EmployeeId;
			return cosmetic;
		}
	}
}
