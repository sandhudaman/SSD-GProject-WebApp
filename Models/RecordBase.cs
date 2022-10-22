using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WebApp.Models
{
    /// <summary>
    /// This Base class contains ID and Creation Time
    /// as many class had same feilds 
    /// This class will be inherited to use ID and Creation Time Feild by Other Classes
    /// </summary>
    [JsonObject]
    [XmlRoot]
    public class RecordBase
    {
        public RecordBase() 
        {
        }

        /// <summary>
        /// Guid id to generate a Key For Table
        /// </summary>
        [Key,Required]
        [XmlElement]
        [JsonProperty]
        public Guid Id { get; set; }

        /// <summary>
        /// Creation tiem to get set date Time when object/record
        /// was created 
        /// </summary>
        [Required]
        [XmlElement]
        [JsonProperty]
        public DateTimeOffset CreationTime { get; set; }


    }
}
