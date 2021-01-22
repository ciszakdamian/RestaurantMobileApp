using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMobileApp.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("price")]
        public double price { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("tableNumber")]
        public int tableNumber { get; set; }
    }
}
