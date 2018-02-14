
using System.Collections.Generic;

namespace IassetBackend.Data.Models
{
    public class Country
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}