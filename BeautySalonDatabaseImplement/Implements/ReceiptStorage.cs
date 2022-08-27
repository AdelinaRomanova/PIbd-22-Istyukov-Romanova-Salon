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
    public class ReceiptStorage : IReceiptStorage
    {
        public List<ReceiptViewModel> GetFullList()
        {
            using (var context = new BeautySalonDatabase())
            {
                return context.Receipts
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.ReceiptCosmetics)
                    .ThenInclude(rec => rec.Cosmetic)
                    .Include(rec => rec.ReceiptPurcheses)
                    .ThenInclude(rec => rec.Purchase)
                    .Select(CreateModel)
                    .ToList();
            }
        }
        public List<ReceiptViewModel> GetFilteredList(ReceiptBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                return context.Receipts
                .Include(rec => rec.Employee)
                .Include(rec => rec.ReceiptCosmetics)
                .ThenInclude(rec => rec.Cosmetic)
                .Include(rec => rec.ReceiptPurcheses)
                .ThenInclude(rec => rec.Purchase)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.EmployeeId == model.EmployeeId) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.EmployeeId == model.EmployeeId && rec.Date.Date >= model.DateFrom.Value.Date && rec.Date.Date <= model.DateTo.Value.Date))
                .Select(CreateModel)
                .ToList();
            }
        }
        public ReceiptViewModel GetElement(ReceiptBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var receipt = context.Receipts
            .Include(rec => rec.Purchases)
            .Include(rec => rec.Employee)
            .Include(rec => rec.ReceiptCosmetics)
            .ThenInclude(rec => rec.Cosmetic)
            .Include(rec => rec.ReceiptPurcheses)
            .ThenInclude(rec => rec.Purchase)
            .FirstOrDefault(rec => rec.Id == model.Id);
            return receipt != null ? CreateModel(receipt) : null;
        }
        public void Insert(ReceiptBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Receipt receipt = new Receipt()
                        {
                            Date = model.Date,
                            TotalCost = model.TotalCost,
                            EmployeeId = (int)model.EmployeeId
                        };
                        context.Receipts.Add(receipt);
                        context.SaveChanges();
                        CreateModel(model, receipt, context);
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
        public void Update(ReceiptBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Receipts.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Чек не найден");
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
        public void Delete(ReceiptBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                Receipt element = context.Receipts.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Receipts.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Чек не найден");
                }
            }
        }
        private Receipt CreateModel(ReceiptBindingModel model, Receipt receipt, BeautySalonDatabase context)
        {
            receipt.TotalCost = model.TotalCost;
            receipt.Date = model.Date;
            receipt.EmployeeId = (int)model.EmployeeId;

            if (receipt.Id == 0)
            {
                context.Receipts.Add(receipt);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var receiptCosmetics = context.ReceiptCosmetics.Where(rec => rec.ReceiptId == model.Id.Value).ToList();
                context.ReceiptCosmetics.RemoveRange(receiptCosmetics.Where(rec => !model.ReceiptCosmetics.ContainsKey(rec.CosmeticId)).ToList());
                context.SaveChanges();

                foreach (var updateCosmetic in receiptCosmetics)
                {
                    updateCosmetic.Count = model.ReceiptCosmetics[updateCosmetic.CosmeticId].Item2;
                    model.ReceiptCosmetics.Remove(updateCosmetic.CosmeticId);
                }
                context.SaveChanges();
            }
            foreach (var rc in model.ReceiptCosmetics)
            {
                context.ReceiptCosmetics.Add(new ReceiptCosmetic
                {
                    ReceiptId = receipt.Id,
                    CosmeticId = rc.Key,
                    Count = rc.Value.Item2
                });
                context.SaveChanges();
            }
            return receipt;
        }
        private ReceiptViewModel CreateModel(Receipt receipt)
        {
            return new ReceiptViewModel
            {
                Id = receipt.Id,
                TotalCost = receipt.TotalCost,
                Date = receipt.Date,
                ReceiptCosmetics = receipt.ReceiptCosmetics
                    .ToDictionary(recRC => recRC.CosmeticId, recRC => (recRC.Cosmetic?.CosmeticName, recRC.Count)),
                EmployeeId = receipt.EmployeeId,
                ReceiptPurchases = receipt.ReceiptPurcheses
                    .ToDictionary(recDC => recDC.PurchaseId, recDC => recDC.Purchase.Price)
            };
        }
    }
}
