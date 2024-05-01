using Newtonsoft.Json;

namespace Apps.BWX.Models.Project.Responses;

public class GenericResponse
{
    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
}