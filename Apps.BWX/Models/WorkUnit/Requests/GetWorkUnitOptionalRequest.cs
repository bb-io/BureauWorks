using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Models.WorkUnit.Requests;

public class GetWorkUnitOptionalRequest
{
    [Display("Work unit ID")]
    public string? WorkUnitId { get; set; }
}