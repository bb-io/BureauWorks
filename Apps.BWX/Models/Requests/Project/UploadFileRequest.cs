using Apps.BWX.DataSourceHandlers;
using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.BWX.Models.Requests.Project;

public class UploadFileRequest
{
    public FileReference File { get; set; }

    [Display("Target locales")]
    [DataSource(typeof(LanguageDataHandler))]
    public List<string> TargetLocales { get; set; }

    [Display("Workflows")]
    [StaticDataSource(typeof(WorkflowDataHandler))]
    public List<string> Workflows { get; set; }

    [Display("File name", Description = "Override file name")]
    public string? FileName { get; set; }

    [Display("File path", Description = "Override file path")]
    public string? FilePath { get; set; }
    public string? Notes { get; set; }
}