using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace BeautySalonContracts.ViewModels
{
    public class VisitViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [DisplayName("Дата посещения")]
        public DateTime Date { get; set; }
        public Dictionary<int, string> VisitProcedures { get; set; }
        public List<int> ProceduresId { get; set; }
    }
}
