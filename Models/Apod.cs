using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Asteroids.Models
{
    public class Apod
    {

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("date")]

        public string Date { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        [JsonProperty("hdurl")]
        public string Hdurl { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("service_version")]
        public string ServiceVersion { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class Picture
    {
        public List<Apod> Pcs { get; set; }
    }
}