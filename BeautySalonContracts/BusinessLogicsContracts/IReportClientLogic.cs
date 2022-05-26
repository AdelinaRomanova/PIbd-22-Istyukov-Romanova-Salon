﻿using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IReportClientLogic
    {
		// Получение списка процедур за определенный период 
		List<ReportProceduresViewModel> GetProcedures(ReportClientBindingModel model);


		// Получение списка выдач по выбранным процедурам 
		List<ReportDistributionProcedureViewModel> GetDistributionList(ReportDistributionProcedureBindingModel model);


		// Сохранение списка выдач в файл-Word
		public void SavePurchaseListToWordFile(ReportClientBindingModel model);


		// Сохранение списка выдач в файл-Excel
		public void SavePurchaseListToExcelFile(ReportClientBindingModel model);


		// Сохранение списка процедур в файл-Pdf
		public void SaveProceduresToPdfFile(ReportClientBindingModel model);
	}
}
