using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApp.Models
{
    /// <summary>
    /// This is the Provider Class.  It inherits two properties from RecordBase; CreationTime and Id.  This class contains a constructor in order 
    /// to create new provider objects. There are 4 properties: FistName, LastName, LicenseNumber and Address, all of which are required. Annotations are
    /// there to work with xml and json.
    /// </summary>
    [XmlRoot]
    [JsonObject]
    [Serializable]
    public class Provider:RecordBase
    {
        /// <summary>
        /// Paramaterless Constructor needed for functonality.
        /// </summary>
        public Provider()
        {

        }
        /// <summary>
        /// This is the constructor for the Provider class. It accepts four paramaters, 3 strings and a uint. 
        /// Id and creationTime are inherited from RecordBase. 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="licenseNumber"></param>
        /// <param name="address"></param>
        /// string firstName, string lastName, uint licenseNumber, string address
        public Provider(string firstName, string lastName, uint licenseNumber, string address)
        {
            this.Id = Guid.NewGuid();
            this.CreationTime = DateTimeOffset.Now;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.LicenseNumber = licenseNumber;
            this.Address = address;

        }


        /// <summary>
        /// A string property for first name, length specified.
        /// </summary>
        [XmlElement]
        [JsonProperty]
        [Required, MinLength(2)]
        [MaxLength(60)]
        public string FirstName { get; set; }

        /// <summary>
        /// A string property for last name, length specified.
        /// </summary>
        [XmlElement]
        [JsonProperty]
        [Required, MinLength(2)]
        [MaxLength(60)]
        public string LastName { get; set; }

        /// <summary>
        /// A uint property for the license number of Provider.
        /// </summary>
        [XmlElement]
        [JsonProperty]
        [Required]
        public uint LicenseNumber { get; set; }

        /// <summary>
        /// A string representing the address of the provider.
        /// </summary>
        [XmlElement]
        [JsonProperty]
        [Required, MinLength(2)]
        [MaxLength(60)]
        public string Address { get; set; }

    }
}
