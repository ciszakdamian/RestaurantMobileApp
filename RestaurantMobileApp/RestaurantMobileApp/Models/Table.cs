using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestaurantMobileApp.Models
{
    public class Table
    {

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("number")]
        public int number { get; set; }

        [JsonProperty("places")]
        public int places { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }

        [JsonProperty("description")]
        public string description{ get; set; }
    }
}
