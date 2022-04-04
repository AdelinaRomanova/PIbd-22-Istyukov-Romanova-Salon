using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.ViewModels
{
    public class DistributionViewModel
    {
        [DisplayName("Номер выдачи")]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? VisitId { get; set; }

        [DisplayName("Дата выдачи")]
        public DateTime IssueDate { get; set; }
        public Dictionary<int, (string, int)> DistributionCosmetics { get; set; }
    }
}
