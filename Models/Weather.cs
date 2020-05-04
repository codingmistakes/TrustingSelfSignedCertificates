using System.Collections.Generic;

namespace TrustingSelfSignedCertificates.Models
{
    public class Weather
    {
        public float lon { get; set; }
        public float lat { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public int temp { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class WeatherData
    {
        public int count { get; set; }
        public List<Weather> data { get; set; }
    }
}
