﻿using BeautySalonContracts.BindingModels;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using BeautySalonDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonDatabaseImplement.Implements
{
    public class PurchaseStorage : IPurchaseStorage
    {
        public List<PurchaseViewModel> GetFullList()
        {
            using (var context = new BeautySalonDatabase())
            {
                return context.Purchases
                .Include(rec => rec.Client)
                .Include(rec => rec.Receipt)
                .Include(rec => rec.ProcedurePurchase)
                .ThenInclude(rec => rec.Procedure)
                .Select(CreateModel)
                .ToList();
            }
        }
        public List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                return context.Purchases
                .Include(rec => rec.Client)
                .Include(rec => rec.Receipt)
                .Include(rec => rec.ProcedurePurchase)
                .ThenInclude(rec => rec.Procedure)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.ClientId == model.ClientId || rec.Date == model.Date || rec.ReceiptId == model.ReceiptId) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && (rec.ClientId == model.ClientId
                && rec.Date.Date >= model.DateFrom.Value.Date && rec.Date.Date <= model.DateTo.Value.Date)))
                .Select(CreateModel)
                .ToList();
            }
        }
        public PurchaseViewModel GetElement(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                var purchase = context.Purchases
                .FirstOrDefault(rec => rec.Date == model.Date || rec.Id == model.Id);
                return purchase != null ? CreateModel(purchase) : null;
            }
        }
        public void Insert(PurchaseBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Purchases.Add(CreateModel(model, new Purchase(), context));
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(PurchaseBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Purchases.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Покупка не найдена");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(PurchaseBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                Purchase element = context.Purchases.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Purchases.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Покупка не найдена");
                }
            }
        }
        private Purchase CreateModel(PurchaseBindingModel model, Purchase purchase, BeautySalonDatabase context)
        {
            purchase.Date = model.Date;
            purchase.ClientId = (int)model.ClientId;
            purchase.Price = model.Price;
            if (model.ReceiptId != null)
            {
                purchase.ReceiptId = (int)model.ReceiptId;
            }
            if (purchase.Id == 0)
            {
                context.Purchases.Add(purchase);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                var PurchaseComponents = context.ProcedurePurchases.Where(rec => rec.PurchaseId == model.Id.Value).ToList();
                context.ProcedurePurchases.RemoveRange(PurchaseComponents.Where(rec =>
                !model.PurchaseProcedures.ContainsKey(rec.ProcedureId)).ToList());

                foreach (var updateProcedure in PurchaseComponents)
                {

                    model.PurchaseProcedures.Remove(updateProcedure.ProcedureId);
                }

                context.SaveChanges();

            }
            // добавили новые
            foreach (var pp in model.PurchaseProcedures)
            {
                context.ProcedurePurchases.Add(new ProcedurePurchase
                {
                    PurchaseId = purchase.Id,
                    ProcedureId = pp.Key,

                });
                context.SaveChanges();
            }
            return purchase;
        }
        private PurchaseViewModel CreateModel(Purchase purchase)
        {
            return new PurchaseViewModel
            {
                Id = purchase.Id,
                ClientId = purchase.ClientId,
                Date = purchase.Date,
                Price = purchase.Price,
                PurchaseProcedures = purchase.ProcedurePurchase.ToDictionary(recPP => recPP.ProcedureId, recPP => (recPP.Procedure?.ProcedureName, recPP.Procedure.Price)),
                ReceiptId = purchase.ReceiptId
            };
        }
    }
}
