using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Immunization
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required,MinLength(2),DisplayName("Vaccine Name")]
        [MaxLength(60)]
        public string OfficialName { get; set; }
        
        [Required,MinLength(2),DisplayName("Trade Name")]
        [MaxLength(60)]
        public string TradeName { get; set; }

        [Required, MinLength(2),DisplayName("Lot Number")]
        [MaxLength(60)]
        public string LotNumber { get; set; }
        
        [Required,DisplayName("Expiration Date")]
        public DateTimeOffset ExpirationDate { get; set; }
        
        [Required,DisplayName("Creation Time")]
        public DateTimeOffset CreationTime { get; set; }
        [DisplayName("Update Time")]
        public DateTimeOffset? UpdatedTime { get; set; }
    }
}
