using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace FabrikamFood2.DataModels
{
    public class Timeline
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }




        [JsonProperty(PropertyName = "Dish")]
        public string Dish { get; set; }

        [JsonProperty(PropertyName = "Rating")]
        public string Rating { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public DateTime Date { get; set; }

    }
}
