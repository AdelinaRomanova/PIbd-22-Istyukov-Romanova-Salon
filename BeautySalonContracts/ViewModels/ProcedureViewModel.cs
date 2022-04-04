using System.ComponentModel;

namespace BeautySalonContracts.ViewModels
{
    public class ProcedureViewModel
    {
		public int Id { get; set; }
		public int ClientId { get; set; }
		[DisplayName("Название процедуры")]
		public string ProcedureName { get; set; }
		[DisplayName("ФИО мастера")]
		public string FIO_Master { get; set; }
		[DisplayName("Продолжительность")]
		public int Duration { get; set; }
		[DisplayName("Цена")]
		public decimal Price { get; set; }
	}
}
