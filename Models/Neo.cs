using Newtonsoft.Json;

namespace Asteroids.Models
{

    public class Neo
    {
        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string tblData { get; set; }

        [JsonProperty("element_count")]
        public int ElementsCount { get; set; }
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, Asteroid[]> NearEarthObjects { get; set; }
    }
}
