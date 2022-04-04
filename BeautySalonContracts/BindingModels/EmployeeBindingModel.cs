using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class EmployeeBindingModel
    {
		public int? Id { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeeSurname { get; set; }
		public string Patronymic { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
