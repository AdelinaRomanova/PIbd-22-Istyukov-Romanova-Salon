using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDatabaseImplement.Models
{
    public class DistributionCosmetic
    {
        public int Id { get; set; }
        public int DistributionId { get; set; }
        public int CosmeticId { get; set; }
        
        [Required]
        public int Count { get; set; }
        public virtual Distribution Distribution { get; set; }
        public virtual Cosmetic Cosmetic { get; set; }
        
    }
}
