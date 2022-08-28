using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IReportEmployeeLogic
    {
		//=========== Получение списка косметики за определенный период =============
		List<ReportCosmeticsViewModel> GetCosmetics(ReportEmployeeBindingModel model);


		//=========== Получение списка покупок клиентов по выбранной косметике ================
		List<ReportPurchaseCosmeticViewModel> GetPurchaseList(ReportEmployeeBindingModel model);


		//=========== Сохранение списка выдач в файл-Word===========
		public void SavePurchaseListToWordFile(ReportEmployeeBindingModel model);


		//=========== Сохранение списка выдач в файл-Excel===========
		public void SavePurchaseListToExcelFile(ReportEmployeeBindingModel model);


		// =========== Сохранение списка косметики в файл-Pdf===========
		public void SaveCosmeticsToPdfFile(ReportEmployeeBindingModel model);
	}
}
