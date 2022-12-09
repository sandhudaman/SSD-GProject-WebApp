using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    /// <summary>
    /// Represents an immunization record for a patient.
    /// </summary>
    public class Immunization
    {
        /// <summary>
        /// The unique identifier for the immunization record.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        // Name of the Vaccine
        [Required,MinLength(2),DisplayName("Vaccine Name")]
        [MaxLength(60)]
        public string OfficialName { get; set; }

        /// <summary>
        /// Trade Name of the Vaccine
        /// </summary>
        [Required,MinLength(2),DisplayName("Trade Name")]
        [MaxLength(60)]
        public string TradeName { get; set; }

        /// <summary>
        /// Lot no. of the Vaccine used
        /// </summary>
        [Required, MinLength(2),DisplayName("Lot Number")]
        [MaxLength(60)]
        public string LotNumber { get; set; }

        /// <summary>
        /// The date the immunization will expire.
        /// </summary>
        [Required,DisplayName("Expiration Date")]
        public DateTimeOffset ExpirationDate { get; set; }
        
        /// <summary>
        /// Date of vaccine Administered
        /// </summary>
        [Required,DisplayName("Creation Time")]
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Date when the record was Updated
        /// </summary>
        [DisplayName("Update Time")]
        public DateTimeOffset? UpdatedTime { get; set; }
    }
}
