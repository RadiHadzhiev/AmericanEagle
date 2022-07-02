using Newtonsoft.Json;

namespace Asteroids.Models
{

    public class Neo
    {
        public string DataStart;
        public string DataEnd;

        [JsonProperty("element_count")]
        public int ElementsCount { get; set; }
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, Asteroid[]> NearEarthObjects { get; set; }
    }
}
