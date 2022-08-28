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
    public class ReportStorage : IReportStorage
    {
        public List<ReportCosmeticsViewModel> GetCosmetics(ReportEmployeeBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                return (
                from c in context.Cosmetics
                join rc in context.ReceiptCosmetics on c.Id equals rc.CosmeticId
                join r in context.Receipts on rc.ReceiptId equals r.Id
                where r.EmployeeId == model.EmployeeId
                where r.Date >= model.DateFrom
                where r.Date <= model.DateTo
                select new ReportCosmeticsViewModel
                {
                    TypeOfService = "Чек",
                    DateOfService = r.Date,
                    CosmeticName = c.CosmeticName,
                    Count = rc.Count
                })
                .Union(
                from c in context.Cosmetics
                join dc in context.DistributionCosmetics on c.Id equals dc.CosmeticId
                join d in context.Distributions on dc.DistributionId equals d.Id
                where d.EmployeeId == model.EmployeeId
                where d.IssueDate >= model.DateFrom
                where d.IssueDate <= model.DateTo
                select new ReportCosmeticsViewModel
                {
                    TypeOfService = "Выдача",
                    DateOfService = d.IssueDate,
                    CosmeticName = c.CosmeticName,
                    Count = dc.Count
                })
                .OrderBy(x => x.DateOfService)
                .ToList();
            }
        }

        public List<ReportPurchaseCosmeticViewModel> GetPurchaseList(int cosmeticId)
        {
            using (var context = new BeautySalonDatabase())
            {
                return (
                from c in context.Cosmetics
                where c.Id == cosmeticId
                join rc in context.ReceiptCosmetics on c.Id equals rc.CosmeticId
                join r in context.Receipts on rc.ReceiptId equals r.Id
                join p in context.Purchases on r.Id equals p.ReceiptId
                select new ReportPurchaseCosmeticViewModel
                {
                    CosmeticName = c.CosmeticName,
                    Price = c.Price,
                    Date = p.Date,
                    Count = rc.Count,
                    ClientId = p.ClientId,
                })
                .ToList();
            }
        }
    }
}
