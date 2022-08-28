using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IReportStorage
    {
        List<ReportPurchaseCosmeticViewModel> GetPurchaseList(int cosmeticId);

        List<ReportCosmeticsViewModel> GetCosmetics(ReportEmployeeBindingModel model);
    }
}
