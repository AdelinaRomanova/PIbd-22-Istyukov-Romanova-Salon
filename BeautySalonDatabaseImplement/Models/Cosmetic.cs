using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BeautySalonDatabaseImplement.Models
{
    public class Cosmetic 
    {
        public int Id { get; set; }
        
        public int EmployeeId { get; set; }
        
        [Required]
        public string CosmeticName { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        public virtual Employee Employee { get; set; }
        
        [ForeignKey("CosmeticId")]
        public virtual List<ReceiptCosmetic> ReceiptCosmetics { get; set; }

        [ForeignKey("CosmeticId")]
        public virtual List<DistributionCosmetic> DistributionCosmetics { get; set; }
    }
}
