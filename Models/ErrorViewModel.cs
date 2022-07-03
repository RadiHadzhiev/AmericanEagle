namespace Asteroids.Models;
using Newtonsoft.Json;


public class ErrorDetails
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}
public class ErrorViewModel
{

    [JsonProperty("error")]
    public ErrorDetails Error { get; set; }
}
