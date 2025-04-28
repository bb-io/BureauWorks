using Newtonsoft.Json;

namespace Apps.BWX.Models.Project.Responses;

public class DownloadTranslationInitiateResponse
{
    [JsonProperty("requestUuid")]
    public string RequestUuid { get; set; } = string.Empty;
    
    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;
}
