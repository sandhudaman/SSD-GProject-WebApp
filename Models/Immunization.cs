using System;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Immunization
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required,MinLength(2)]
        [MaxLength(60)]
        public string OfficialName { get; set; }
        
        [Required,MinLength(2)]
        [MaxLength(60)]
        public string TradeName { get; set; }

        [Required, MinLength(2)]
        [MaxLength(60)]
        public string LotNumber { get; set; }
        
        [Required]
        public DateTimeOffset ExpirationDate { get; set; }
        
        [Required]
        public DateTimeOffset CreationTime { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }
    }
}
