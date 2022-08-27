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
    public class DistributionStorage : IDistributionStorage
    {
        public List<DistributionViewModel> GetFullList()
        {
            using (var context = new BeautySalonDatabase())
            {
                return context.Distributions
                .Include(rec => rec.Employee)
                .Include(rec => rec.Visit)
                .Include(rec => rec.DistributionCosmetics)
                .ThenInclude(rec => rec.Cosmetic)
                .Select(CreateModel)
                .ToList();
            }
        }
        public List<DistributionViewModel> GetFilteredList(DistributionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                return context.Distributions
                .Include(rec => rec.Employee)
                .Include(rec => rec.Visit)
                .Include(rec => rec.DistributionCosmetics)
                .ThenInclude(rec => rec.Cosmetic)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.EmployeeId == model.EmployeeId) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.EmployeeId == model.EmployeeId && rec.IssueDate.Date >= model.DateFrom.Value.Date && rec.IssueDate.Date <= model.DateTo.Value.Date))
                .Select(CreateModel)
                .ToList();
            }
        }
        public DistributionViewModel GetElement(DistributionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                var distribution = context.Distributions
                .Include(rec => rec.Employee)
                .Include(rec => rec.Visit)
                .Include(rec => rec.DistributionCosmetics)
                .ThenInclude(rec => rec.Cosmetic)
                .FirstOrDefault(rec => rec.IssueDate == model.IssueDate || rec.Id == model.Id);
                return distribution != null ? CreateModel(distribution) : null;
            }
        }
        public void Insert(DistributionBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Distributions.Add(CreateModel(model, new Distribution(), context));
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
        public void Update(DistributionBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Distributions.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Выдача не найдена");
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
        public void Delete(DistributionBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                Distribution element = context.Distributions.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Distributions.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Выдача не найдена");
                }
            }
        }
        private Distribution CreateModel(DistributionBindingModel model, Distribution distribution, BeautySalonDatabase context)
        {
            distribution.IssueDate = model.IssueDate;
            distribution.EmployeeId = (int)model.EmployeeId;
            distribution.VisitId = model.VisitId;

            if (distribution.Id == 0)
            {
                context.Distributions.Add(distribution);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var distributionCosmetics = context.DistributionCosmetics.Where(rec => rec.DistributionId == model.Id.Value).ToList();
                context.DistributionCosmetics.RemoveRange(distributionCosmetics.Where(rec => !model.DistributionCosmetics.ContainsKey(rec.CosmeticId)).ToList());
                context.SaveChanges();

                foreach (var updateCosmetic in distributionCosmetics)
                {
                    updateCosmetic.Count = model.DistributionCosmetics[updateCosmetic.CosmeticId].Item2;
                    model.DistributionCosmetics.Remove(updateCosmetic.CosmeticId);
                }
                context.SaveChanges();
            }
            foreach (var dc in model.DistributionCosmetics)
            {
                context.DistributionCosmetics.Add(new DistributionCosmetic
                {
                    DistributionId = distribution.Id,
                    CosmeticId = dc.Key,
                    Count = dc.Value.Item2
                });
                context.SaveChanges();
            }
            return distribution;
        }
        private DistributionViewModel CreateModel(Distribution distribution)
        {
            return new DistributionViewModel
            {
                Id = distribution.Id,
                IssueDate = distribution.IssueDate,
                DistributionCosmetics = distribution.DistributionCosmetics
                    .ToDictionary(recDC => recDC.CosmeticId, recDC => (recDC.Cosmetic?.CosmeticName, recDC.Count)),
                EmployeeId = distribution.EmployeeId,
                VisitId = distribution.VisitId
            };
        }
    }
}
