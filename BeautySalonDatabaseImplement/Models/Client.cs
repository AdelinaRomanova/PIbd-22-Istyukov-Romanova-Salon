using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BeautySalonDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        
        [Required]
        public string ClientName { get; set; }
        
        [Required]
        public string ClientSurname { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        
        [ForeignKey("ClientId")]
        public List<Visit> Visit { get; set; }
        
        [ForeignKey("ClientId")]
        public List<Procedure> Procedure { get; set; }

        [ForeignKey("ClientId")]
        public List<Purchase> Purchase { get; set; }
    }
}
