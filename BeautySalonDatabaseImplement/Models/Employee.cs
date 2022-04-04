using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BeautySalonDatabaseImplement.Models
{
    public class Employee
    {
		public int Id { get; set; }

		[Required]
		public string EmployeeName { get; set; }

		[Required]
		public string EmployeeSurname { get; set; }

		public string Patronymic { get; set; }

		[Required]
		public string Login { get; set; }

		[Required]
		public string Password { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual List<Cosmetic> Cosmetic { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual List<Distribution> Distribution { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual List<Receipt> Receipt { get; set; }
	}
}
