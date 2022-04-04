using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BeautySalonDatabaseImplement.Models
{
    public class Distribution
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int VisitId { get; set; }
        
        [Required]
        public DateTime IssueDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Visit Visit { get; set; }

        [ForeignKey("DistributionId")]
        public virtual List<DistributionCosmetic> DistributionCosmetics { get; set; }
    }
}
