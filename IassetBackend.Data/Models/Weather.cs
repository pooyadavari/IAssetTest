using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IassetBackend.Data.Models
{
    public class Weather
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public string Location { get; set; }        
        public string Time { get; set; }        
        public string Wind { get; set; }        
        public string Visibility { get; set; }        
        public string SkyConditions { get; set; }        
        public string Temperature { get; set; }        
        public string DewPoint { get; set; }        
        public string RelativeHumidity { get; set; }      
        public string Pressure { get; set; }        
        public string Status { get; set; }
    }
}
