using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitController
    {
        private readonly IVisitLogic _visitLogic;
        private readonly IProcedureLogic _procedureLogic;

        public VisitController(IVisitLogic visitLogic, IProcedureLogic procedureLogic)
        {
            _visitLogic = visitLogic;
            _procedureLogic = procedureLogic;
        }

        [HttpGet]
        public List<VisitViewModel> GetVisitList() => _visitLogic.Read(null)?.ToList();
        [HttpGet]
        public List<ProcedureViewModel> GetProcedureList() => _procedureLogic.Read(null)?.ToList();

        [HttpGet]
        public ProcedureViewModel GetProcedure(int procedureId) => _procedureLogic.Read(new ProcedureBindingModel { Id = procedureId })?[0];

        [HttpGet]
        public VisitViewModel GetVisit(int visitId) => _visitLogic.Read(new VisitBindingModel { Id = visitId })?[0];

        [HttpPost]
        public void CreateOrUpdateVisit(VisitBindingModel model) => _visitLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteVisit(VisitBindingModel model) => _visitLogic.Delete(model);
    }
}
