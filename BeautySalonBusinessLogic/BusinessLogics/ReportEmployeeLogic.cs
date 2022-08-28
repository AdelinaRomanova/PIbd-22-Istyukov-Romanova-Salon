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
    public class ReportEmployeeLogic : IReportEmployeeLogic
    {
        private readonly IReceiptStorage _receiptStorage;
        private readonly IPurchaseStorage _purchaseStorage;
        private readonly IDistributionStorage _distributionStorage;
        private readonly IReportStorage _reportStorage;
        private readonly AbstractSaveToExcelEmployee _saveToExcel;
        private readonly AbstractSaveToWordEmployee _saveToWord;
        private readonly AbstractSaveToPdfEmployee _saveToPdf;

        public ReportEmployeeLogic(
            IReceiptStorage receiptStorage, IPurchaseStorage purchaseStorage, IDistributionStorage distributionStorage, IReportStorage reportStorage,
            AbstractSaveToExcelEmployee saveToExcel, AbstractSaveToWordEmployee saveToWord, AbstractSaveToPdfEmployee saveToPdf)
        {
            _receiptStorage = receiptStorage;
            _purchaseStorage = purchaseStorage;
            _distributionStorage = distributionStorage;
            _reportStorage = reportStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка косметики, связанной с чеками и выдачей
        public List<ReportCosmeticsViewModel> GetCosmetics(ReportEmployeeBindingModel model)
        {
            var listAll = new List<ReportCosmeticsViewModel>();

            var listReceipts = _receiptStorage.GetFilteredList(new ReceiptBindingModel { EmployeeId = model.EmployeeId, DateFrom = model.DateFrom, DateTo = model.DateTo });
            foreach (var receipt in listReceipts)
            {
                foreach (var rec in receipt.ReceiptCosmetics)
                {
                    listAll.Add(new ReportCosmeticsViewModel
                    {
                        TypeOfService = "Чек",
                        DateOfService = receipt.Date,
                        CosmeticName = rec.Value.Item1,
                        Count = rec.Value.Item2
                    });
                }
            }
            var listDistributions = _distributionStorage.GetFilteredList(new DistributionBindingModel { EmployeeId = model.EmployeeId, DateFrom = model.DateFrom, DateTo = model.DateTo });
            foreach (var distribution in listDistributions)
            {
                foreach (var dp in distribution.DistributionCosmetics)
                {
                    listAll.Add(new ReportCosmeticsViewModel
                    {
                        TypeOfService = "Выдача",
                        DateOfService = distribution.IssueDate,
                        CosmeticName = dp.Value.Item1,
                        Count = dp.Value.Item2
                    });
                }
            }
            return listAll;
        }

        // Получение списка выдач по выбранным процедурам
        public List<ReportPurchaseCosmeticViewModel> GetPurchaseList(ReportEmployeeBindingModel model)
        {
            var list = new List<ReportPurchaseCosmeticViewModel>();
            decimal totalCost = 0;

            foreach (var cosmetic in model.purchaseCosmetics)
            {
                list.AddRange(_reportStorage.GetPurchaseList(cosmetic));
            }

            foreach (var reportPurchaseCosmetic in list)
            {
                totalCost += reportPurchaseCosmetic.Price * reportPurchaseCosmetic.Count;
            }

            list[0].TotalCost = totalCost;
            return list;
        }

        // Сохранение покупок в файл-Word
        public void SavePurchaseListToWordFile(ReportEmployeeBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfoEmployee
            {
                FileName = model.FileName,
                Title = "Сведения по покупкам",
                PurchasesCosmetic = GetPurchaseList(model)
            });
        }

        // Сохранение покупок в файл-Excel
        public void SavePurchaseListToExcelFile(ReportEmployeeBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfoEmployee
            {
                FileName = model.FileName,
                Title = "Сведения по покупкам",
                PurchasesCosmetic = GetPurchaseList(model)
            });
        }

        /// Сохранение выдач в файл-Pdf
        public void SaveCosmeticsToPdfFile(ReportEmployeeBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfoEmployee
            {
                FileName = model.FileName,
                Title = "Список процедур",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Cosmetics = GetCosmetics(model)
            });
        }
    }
}
