using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IReportClientLogic
    {
		// Получение списка выдач по выбранным процедурам 
		List<ReportDistributionProcedureViewModel> GetDistributionList(ReportDistributionProcedureBindingModel model);

		// Получение списка процедур за определенный период 
		List<ReportProceduresViewModel> GetProcedures(ReportClientBindingModel model);

		// Сохранение списка выдач в файл-Word
		public void SaveProcedureDistributionsToWordFile(ReportClientBindingModel model);


		// Сохранение списка выдач в файл-Excel
		public void SaveProcedureDistributionsToExcelFile(ReportClientBindingModel model);


		// Сохранение списка процедур в файл-Pdf
		public void SaveProcedureToPdfFile(ReportClientBindingModel model);
	}
}
