using Apps.BWX.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Requests.Project;

public class CreateProjectRequest
{
    public string Reference { get; set; }

    [Display("Client")]
    [DataSource(typeof(ClientDataHandler))]
    public string OrgUnitUUID { get; set; }

    [Display("Contact person")]
    [DataSource(typeof(UserDataHandler))]
    public string ContactUUID { get; set; }

    [Display("Source locale")]
    [DataSource(typeof(LanguageDataHandler))]
    public string SourceLocale { get; set; }
    public string? Notes { get; set; }
    //public string Timezone { get; set; } missing on UI
    //public string Currency { get; set; } missing on UI
    public List<string>? Tags { get; set; }

    [Display("Infer default settings", Description = "Set \"true\" to automatically infer the default settings of a project based on its Organizational unit's settings, such as price list, currency, autopilot, and so on.")]
    public bool? InferDefaultSettings { get; set; }
}