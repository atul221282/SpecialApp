using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Transport.Special
{
    public class ClientLocation
    {
        //[JsonProperty("accuracy")]
        public long Accuracy { get; set; }
        //[JsonProperty("latitude")]
        public double Latitude { get; set; }
        //[JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
