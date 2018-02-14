
using System.Xml.Serialization;

namespace IassetBackend.Data.Models.ServiceModels
{
    [XmlRoot(ElementName = "Table")]
    public class CitiesOfCountry
    {
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
    }
}