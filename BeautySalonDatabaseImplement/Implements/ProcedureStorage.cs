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
    public class ProcedureStorage : IProcedureStorage
    {
        public List<ProcedureViewModel> GetFullList()
        {
            using (var context = new BeautySalonDatabase())
            {
                return context.Procedures
                .Select(CreateModel)
                .ToList();
            }
        }
        public List<ProcedureViewModel> GetFilteredList(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                return context.Procedures
                .Where(rec => rec.ClientId == model.ClientId || rec.ProcedureName.Contains(model.ProcedureName))
                .Select(CreateModel)
                .ToList();
            }
        }
        public ProcedureViewModel GetElement(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var procedure = context.Procedures
                .Include(rec => rec.ProcedurePurchase)
                .ThenInclude(rec => rec.Purchase)
                .FirstOrDefault(rec => rec.ProcedureName == model.ProcedureName || rec.Id == model.Id);
                return procedure != null ? CreateModel(procedure) : null;
        }
        public void Insert(ProcedureBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                context.Procedures.Add(CreateModel(model, new Procedure()));
                context.SaveChanges();
            }
        }
        public void Update(ProcedureBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                var element = context.Procedures.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Процедура не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(ProcedureBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                Procedure element = context.Procedures.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Procedures.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Процедура не найдена");
                }
            }
        }
        private ProcedureViewModel CreateModel(Procedure procedure)
        {
            return new ProcedureViewModel
            {
                Id = procedure.Id,
                ProcedureName = procedure.ProcedureName,
                FIO_Master = procedure.FIO_Master,
                Duration = procedure.Duration,
                Price = procedure.Price,
                ClientId = procedure.ClientId
            };
        }
        private Procedure CreateModel(ProcedureBindingModel model, Procedure procedure)
        {
            procedure.ProcedureName = model.ProcedureName;
            procedure.FIO_Master = model.FIO_Master;
            procedure.Price = model.Price;
            procedure.Duration = model.Duration;
            procedure.ClientId = model.ClientId.Value;
            return procedure;
        }
    }
}
