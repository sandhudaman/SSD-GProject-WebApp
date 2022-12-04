using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WebApp.Models
{
    
    /// <summary>
    /// Patients Calls inheriting Records base objects Id and Creation Time
    /// </summary>
    [JsonObject]
    [XmlRoot]
    public class Patient:RecordBase
    {
        //initialiizing patient class
        public Patient(){
            this.CreationTime = DateTimeOffset.Now;
			this.Id = Guid.NewGuid();
           
        }
        /// <summary>
        /// String Firstname With max char length 60
        /// </summary>
        [Required]
        [JsonProperty]
        [XmlElement]
        [MinLength(2)]
        [MaxLength(60)]
        public string FirstName { get; set; }

        /// <summary>
        /// String LastName with char Lenght 60
        /// </summary>
        [Required]
        [JsonProperty]
        [MinLength(2)]
        [MaxLength(60)]
        public string LastName { get; set; }
         
        /// <summary>
        /// Date of Birth uses Creation Time object to Save 
        /// </summary>
        [Required]
        [JsonProperty]
        [XmlElement]
        public DateTimeOffset DateOfBirth
        {
            get => this.CreationTime;
            set => this.CreationTime = value;
        }
    }
}
