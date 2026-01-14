using Newtonsoft.Json;

namespace Apps.BWX.Dtos;

// Had to create this instead of using WorkUnitDto because that class contains ProjectResourceUuid
// which is a nested object in GET /work-unit response instead of string
public class WorkUnitDataHandlerDto
{
    public string Uuid { get; set; }

    [JsonProperty("workflow")]
    public string WorkflowName { get; set; }
}
