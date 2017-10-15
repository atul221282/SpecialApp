using Newtonsoft.Json;

namespace SpecialApp.Transport.Special
{
    public class ClientLocation
    {
        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
