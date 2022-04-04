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
    public class VisitStorage : IVisitStorage
    {
        public List<VisitViewModel> GetFullList()
        {
            using (var context = new BeautySalonDatabase())
            {
                return context.Visits
                .Include(rec => rec.Client)
                .Include(rec => rec.ProcedureVisit)
                .ThenInclude(rec => rec.Procedure)
                .Select(CreateModel)
                .ToList();
            }
        }
        public List<VisitViewModel> GetFilteredList(VisitBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                return context.Visits
                .Include(rec => rec.Client)
                .Include(rec => rec.ProcedureVisit)
                .ThenInclude(rec => rec.Procedure)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.ClientId == model.ClientId || rec.Date == model.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && (rec.ClientId == model.ClientId
                && rec.Date.Date >= model.DateFrom.Value.Date && rec.Date.Date <= model.DateTo.Value.Date)))
                .Select(CreateModel)
                .ToList();
            }
        }
        public VisitViewModel GetElement(VisitBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BeautySalonDatabase())
            {
                var visit = context.Visits
                .FirstOrDefault(rec => rec.Date == model.Date || rec.Id == model.Id);
                return visit != null ? CreateModel(visit) : null;
            }
        }
        public void Insert(VisitBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Visits.Add(CreateModel(model, new Visit(), context));
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
        public void Update(VisitBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Visits.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Посещение не найдено");
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
        public void Delete(VisitBindingModel model)
        {
            using (var context = new BeautySalonDatabase())
            {
                Visit element = context.Visits.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Visits.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Посещение не найдено");
                }
            }
        }
        private Visit CreateModel(VisitBindingModel model, Visit visit, BeautySalonDatabase context)
        {
            visit.Date = model.Date;
            visit.ClientId = (int)model.ClientId;

            if (visit.Id == 0)
            {
                context.Visits.Add(visit);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var VisitComponents = context.ProcedureVisits.Where(rec => rec.VisitId == model.Id.Value).ToList();
                context.ProcedureVisits.RemoveRange(VisitComponents.Where(rec => !model.VisitProcedures.ContainsKey(rec.ProcedureId)).ToList());
                foreach (var updateProcedure in VisitComponents)
                {
                    model.VisitProcedures.Remove(updateProcedure.ProcedureId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var vp in model.VisitProcedures)
            {
                context.ProcedureVisits.Add(new ProcedureVisit
                {
                    VisitId = visit.Id,
                    ProcedureId = vp.Key,
                });
                context.SaveChanges();
            }
            return visit;
        }
        private VisitViewModel CreateModel(Visit visit)
        {
            return new VisitViewModel
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                Date = visit.Date,
                VisitProcedures = visit.ProcedureVisit.ToDictionary(recPP => recPP.ProcedureId, recPP => (recPP.Procedure?.ProcedureName))
            };
        }
    }
}
