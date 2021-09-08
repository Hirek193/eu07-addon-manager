using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace MaSzyna_Unofficial_Content_Manager
{
    public class API
    {

    }

    public class Addon
    {
        string nameNonJson, type;

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("author")]
        public string author { get; set; }
        [JsonProperty("added_by")]
        public string added_by { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("addonType")]
        public string addonType { get; set; }
        public string displayName { get { return "[" + addonType + "] " + name; } }
    }
}
