using Newtonsoft.Json;

namespace Apps.BWX.Dtos;

public class WorkUnitCreateDto
{
    [JsonProperty("projectResourceUuid")]
    public string ProjectResourceUuid { get; set; }

    [JsonProperty("workflows")]
    public List<string> Workflows { get; set; }

    [JsonProperty("targetLocales")]
    public List<string> TargetLocales { get; set; }
}