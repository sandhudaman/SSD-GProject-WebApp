using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApp.Models
{
    /// <summary>
    /// Organization class
    /// </summary>
    [XmlRoot]
    [XmlType]
    [JsonObject]
    [Serializable]
    public class Organization : RecordBase
    {
        /// <summary>
        /// Constructor for Organization class
        /// </summary>
        public Organization()
        {
            this.Id = Guid.NewGuid();
            this.CreationTime = DateTimeOffset.Now;
        }

        /// <summary>
        /// Organization Name
        /// </summary>
        /// <value>Name of Organization</value>
        [XmlElement]
        [JsonProperty]
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Organization Type
        /// will default to 'Hospital' if Type is not correctly specified
        /// </summary>
        /// <value>Type of Organization</value>
        [XmlElement]
        [JsonProperty]
        [Required]
        public string Type
        {
            get { return type; }
            set
            {
                switch (value.ToLower())
                {
                    case "hospital":
                        type = "Hospital";
                        break;
                    case "clinic":
                        type = "Clinic";
                        break;
                    case "pharmacy":
                        type = "Pharmacy";
                        break;
                    default:
                        //if type has been previously Set, leave it alone
                        //otherwise default to Hospital
                        if (type == "" || type == null)
                        {
                            type = "Hospital";
                        }
                        break;
                }
            }
        }
        private string type;

        /// <summary>
        /// Organization Address
        /// </summary>
        /// <value>Address of Organization</value>
        [XmlElement]
        [JsonProperty]
        [Required]
        public string Address { get; set; }

    }

}
