using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System.Collections.Generic;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IDistributionLogic
    {
        List<DistributionViewModel> Read(DistributionBindingModel model);
        void CreateOrUpdate(DistributionBindingModel model);
        void Delete(DistributionBindingModel model);
        void Linking(DistributionLinkingBindingModel model);
    }
}
