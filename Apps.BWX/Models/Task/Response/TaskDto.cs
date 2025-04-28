using Apps.BWX.Converters;
using Apps.BWX.Dtos;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Models.Task.Response;

public class TaskDto
{
    [Display("Task ID"), JsonProperty("uuid")]
    public string Uuid { get; set; } = string.Empty;

    [Display("Task status"), JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    public string Client { get; set; } = string.Empty;

    public ProjectDto Project { get; set; } = new();

    [Display("Creation date"), JsonProperty("creationDate"), JsonConverter(typeof(DateTimeConverter))]
    public DateTime CreationDate { get; set; }

    [Display("Due date"), JsonProperty("dueDate"), JsonConverter(typeof(DateTimeConverter))]
    public DateTime DueDate { get; set; }

    [Display("Delivery date"), JsonProperty("deliveryDate"), JsonConverter(typeof(DateTimeConverter))]
    public DateTime DeliveryDate { get; set; }

    [Display("Work unit")]
    public WorkUnitDto WorkUnit { get; set; } = new();
}

public class WorkUnitDto
{
    [Display("Work unit ID"), JsonProperty("uuid")]
    public string Uuid { get; set; }

    public string Workflow { get; set; } = string.Empty;

    [Display("File name")]
    public string Name { get; set; } = string.Empty;
}