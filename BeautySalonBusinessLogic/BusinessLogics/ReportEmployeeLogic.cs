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
    class ReportEmployeeLogic : IReportEmployeeLogic
    {
        private readonly IReceiptStorage _receiptStorage;
        private readonly IPurchaseStorage _purchaseStorage;
        private readonly IDistributionStorage _distributionStorage;
        private readonly AbstractSaveToExcelEmployee _saveToExcel;
        private readonly AbstractSaveToWordEmployee _saveToWord;
        private readonly AbstractSaveToPdfEmployee _saveToPdf;

        public ReportEmployeeLogic(
            IReceiptStorage receiptStorage, IPurchaseStorage purchaseStorage, IDistributionStorage distributionStorage,
            AbstractSaveToExcelEmployee saveToExcel, AbstractSaveToWordEmployee saveToWord, AbstractSaveToPdfEmployee saveToPdf)
        {
            _receiptStorage = receiptStorage;
            _purchaseStorage = purchaseStorage;
            _distributionStorage = distributionStorage;
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
                    });
                }
            }
            return listAll;
        }

        // Получение списка выдач по выбранным процедурам
        public List<ReportPurchaseCosmeticViewModel> GetPurchaseList(ReportPurchaseCosmeticBindingModel model)
        {
            var listReceipts = _receiptStorage.GetFullList();
            var list = new List<ReportPurchaseCosmeticViewModel>();

            foreach (var receipt in listReceipts)
            {
                foreach (var rp in receipt.ReceiptCosmetics)
                {
                    if (rp.Value.Item1 == model.CosmeticName)
                    {
                        var listPurchase = _purchaseStorage.GetFilteredList(new PurchaseBindingModel { ReceiptId = receipt.Id });
                        if (listPurchase.Count > 0 && listPurchase != null)
                        {
                            foreach (var purchase in listPurchase)
                            {
                                list.Add(new ReportPurchaseCosmeticViewModel
                                {
                                    CosmeticName = rp.Value.Item1,
                                    Date = purchase.Date,
                                    ClientId = (int)purchase.ClientId
                                });

                            }
                        }
                    }
                }
            }

            return list;
        }

        // Сохранение покупок в файл-Word
        public void SavePurchaseListToWordFile(ReportEmployeeBindingModel model, string name)
        {
            _saveToWord.CreateDoc(new WordInfoEmployee
            {
                FileName = model.FileName,
                Title = "Сведения по выдачам",
                PurchasesCosmetic = GetPurchaseList(new ReportPurchaseCosmeticBindingModel { CosmeticName = name })
            });
        }

        // Сохранение покупок в файл-Excel
        public void SavePurchaseListToExcelFile(ReportEmployeeBindingModel model, string name)
        {
            _saveToExcel.CreateReport(new ExcelInfoEmployee
            {
                FileName = model.FileName,
                Title = "Сведения по выдачам",
                PurchasesCosmetic = GetPurchaseList(new ReportPurchaseCosmeticBindingModel { CosmeticName = name })
            });
        }

        /// Сохранение косметики в файл-Pdf
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
