
using System.Xml.Serialization;

namespace IassetBackend.Data.Models.ServiceModels
{
    [XmlRoot(ElementName = "CurrentWeather")]
    public class WeatherResult
    {
        [XmlElement(ElementName = "Location")]
        public string Location { get; set; }

        [XmlElement(ElementName = "Time")]
        public string Time { get; set; }

        [XmlElement(ElementName = "Wind")]
        public string Wind { get; set; }

        [XmlElement(ElementName = "Visibility")]
        public string Visibility { get; set; }

        [XmlElement(ElementName = "SkyConditions")]
        public string SkyConditions { get; set; }

        [XmlElement(ElementName = "Temperature")]
        public string Temperature { get; set; }

        [XmlElement(ElementName = "DewPoint")]
        public string DewPoint { get; set; }

        [XmlElement(ElementName = "RelativeHumidity")]
        public string RelativeHumidity { get; set; }

        [XmlElement(ElementName = "Pressure")]
        public string Pressure { get; set; }

        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
    }
}
