using Newtonsoft.Json;


namespace Asteroids.Models
{
    public struct Diameter
    {
        [JsonProperty("estimated_diameter_min")]
        public double min;
        [JsonProperty("estimated_diameter_max")]
        public double max;
    }

    public class ApproachData
    {
        [JsonProperty("close_approach_date")]
        public DateTime CloseApproachDate { get; set; }
        [JsonProperty("relative_velocity")]
        public Dictionary<string, double> Velocity { get; set; }
        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }
    }
    public class Asteroid
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("estimated_diameter")]
        public Dictionary<string, Diameter> EstDiameter { get; set; }

        [JsonProperty("close_approach_data")]
        public ApproachData[] ApproachData { get; set; }


    }
}