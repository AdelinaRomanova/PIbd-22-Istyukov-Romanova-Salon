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
	public class MainController : ControllerBase
	{
		private readonly IProcedureLogic _procedure;
		private readonly IPurchaseLogic _purchase;
		private readonly IVisitLogic _visit;
		public MainController(IProcedureLogic procedure, IVisitLogic visit)
		{
			_procedure = procedure;
			_visit = visit;
		}

		// операции с процедурами
		[HttpGet]
		public List<ProcedureViewModel> GetProcedureList(int clientId) => _procedure.Read(new ProcedureBindingModel { ClientId = clientId });

		[HttpGet]
		public ProcedureViewModel GetProcedure(int id) => _procedure.Read(new ProcedureBindingModel { Id = id })?[0];

		[HttpPost]
		public void CreateProcedure(ProcedureBindingModel model) => _procedure.CreateOrUpdate(model);

		[HttpPost]
		public void DeleteProcedure(ProcedureBindingModel model) => _procedure.Delete(model);

		[HttpGet]
		public List<ProcedureViewModel> GetProcedures() => _procedure.Read(null)?.ToList();

		// операции с покупками
		


	}
}
