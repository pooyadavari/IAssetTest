
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IassetBackend.Data.Models.ServiceModels
{
    [XmlRoot(ElementName = "NewDataSet")]
    public class CitiesOfCountryResult
    {
        [XmlElement(ElementName = "Table")]
        public List<CitiesOfCountry> CitiesOfCountry { get; set; }
    }
}