using Newtonsoft.Json;

namespace Apps.BWX.Models.Project.Responses;

public class DownloadTranslationStatusResponse
{
    [JsonProperty("requestUuid")]
    public string RequestUuid { get; set; } = string.Empty;
    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;
    [JsonProperty("downloadUrl")]
    public string DownloadUrl { get; set; } = string.Empty;
}
