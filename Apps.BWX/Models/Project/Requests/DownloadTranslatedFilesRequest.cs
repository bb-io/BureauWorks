using Apps.BWX.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Project.Requests;

public class DownloadTranslatedFilesRequest
{
    [DataSource(typeof(ProjectResourcesDataHandler))]
    public List<string>? Resources { get; set; }

    [Display("Locales")]
    [DataSource(typeof(LanguageDataHandler))]
    public List<string>? Locales { get; set; }
}