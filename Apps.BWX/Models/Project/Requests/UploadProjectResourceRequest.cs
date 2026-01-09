using Apps.BWX.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Project.Requests;

public class UploadProjectResourceRequest
{
    [Display("File")]
    public FileReference File { get; set; }

    [Display("Work unit UUID")]
    [DataSource(typeof(WorkUnitDataHandler))]
    public string WorkUnitUuid { get; set; }

    [Display("Confirm only changed segments")]
    public bool ConfirmOnlyChangedSegments { get; set; }

    [Display("Confirm all imported segments")]
    public bool ConfirmAllImportedSegments { get; set; }

    [Display("File name", Description = "Override file name")]
    public string? FileName { get; set; }

    [Display("File path", Description = "Override file path")]
    public string? FilePath { get; set; }

    [Display("Notes")]
    public string? Notes { get; set; }
}
