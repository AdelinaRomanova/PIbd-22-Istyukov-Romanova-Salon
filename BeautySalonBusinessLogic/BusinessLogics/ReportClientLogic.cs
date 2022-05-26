using BeautySalonBusinessLogic.OfficePackage;
using BeautySalonBusinessLogic.OfficePackage.HelperModels;
using BeautySalonBusinessLogic.OfficePackage.Implements;
using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonBusinessLogic.BusinessLogics
{
    public class ReportClientLogic : IReportClientLogic
    {
        private readonly IVisitStorage _visitStorage;
        private readonly IPurchaseStorage _purchaseStorage;
        private readonly IDistributionStorage _distributionStorage;
        private readonly AbstractSaveToExcelClient _saveToExcel;
        private readonly AbstractSaveToWordClient _saveToWord;
        private readonly AbstractSaveToPdfClient _saveToPdf;

        public ReportClientLogic(
            IVisitStorage visitStorage, IPurchaseStorage purchaseStorage, IDistributionStorage distributionStorage,
            AbstractSaveToExcelClient saveToExcel, AbstractSaveToWordClient saveToWord, AbstractSaveToPdfClient saveToPdf)
        {
            _visitStorage = visitStorage;
            _purchaseStorage = purchaseStorage;
            _distributionStorage = distributionStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка процедур, связанных с покупками и посещениями
        public List<ReportProceduresViewModel> GetProcedures(ReportClientBindingModel model)
        {
            var listAll = new List<ReportProceduresViewModel>();

            var listPurchases = _purchaseStorage.GetFilteredList(new PurchaseBindingModel { ClientId = (int)model.ClientId, DateFrom = model.DateFrom, DateTo = model.DateTo });
            foreach (var purchase in listPurchases)
            {
                foreach (var purch in purchase.PurchaseProcedures)
                {
                    listAll.Add(new ReportProceduresViewModel
                    {
                        TypeOfService = "Покупка",
                        DateOfService = purchase.Date,
                        ProcedureName = purch.Value.Item1,
                        Price = purch.Value.Item2,
                    });
                }
            }
            var listVisits = _visitStorage.GetFilteredList(new VisitBindingModel { ClientId = model.ClientId, DateFrom = model.DateFrom, DateTo = model.DateTo });
            foreach (var visit in listVisits)
            {
                foreach (var vp in visit.VisitProcedures)
                {
                    listAll.Add(new ReportProceduresViewModel
                    {
                        TypeOfService = "Посещение",
                        DateOfService = visit.Date,
                        ProcedureName = vp.Value,
                    });
                }
            }
            return listAll;
        }

        // Получение списка выдач по выбранным процедурам
        public List<ReportDistributionProcedureViewModel> GetDistributionList(ReportDistributionProcedureBindingModel model)
        {
            var listVisits = _visitStorage.GetFullList();
            var list = new List<ReportDistributionProcedureViewModel>();

            foreach (var visit in listVisits)
            {
                foreach (var vp in visit.VisitProcedures)
                {
                    if (vp.Value == model.ProcedureName)
                    {
                        var listDistribution = _distributionStorage.GetFilteredList(new DistributionBindingModel { VisitId = visit.Id });
                        if (listDistribution.Count > 0 && listDistribution != null)
                        {
                            foreach (var distribution in listDistribution)
                            {
                                list.Add(new ReportDistributionProcedureViewModel
                                {
                                    ProcedureName = vp.Value,
                                    Date = distribution.IssueDate,
                                    EmployeeId = (int)distribution.EmployeeId
                                });

                            }
                        }
                    }
                }
            }

            return list;
        }
       
        // Сохранение покупок в файл-Word
        public void SavePurchaseListToWordFile(ReportClientBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfoClient
            {
                FileName = model.FileName,
                Title = "Сведения по выдачам",
                DistributionProcedure = GetDistributionList(new ReportDistributionProcedureBindingModel())
            });
        }
        
        // Сохранение покупок в файл-Excel
        public void SavePurchaseListToExcelFile(ReportClientBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfoClient
            {
                FileName = model.FileName,
                Title = "Сведения по выдачам",
                DistributionProcedure = GetDistributionList(new ReportDistributionProcedureBindingModel())
            });
        }

        /// Сохранение процедур в файл-Pdf
        public void SaveProceduresToPdfFile(ReportClientBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfoClient
            {
                FileName = model.FileName,
                Title = "Список процедур",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Procedures = GetProcedures(model)
            });
        }
    }
}
