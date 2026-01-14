using Apps.BWX.DataSourceHandlers;
using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.BWX.Models.Project.Requests;

public class UploadProjectResourceRequest
{
    [Display("File")]
    public FileReference File { get; set; }

    [Display("Import file type")]
    [StaticDataSource(typeof(LocKitTypeHandler))]
    public string ImportFileType { get; set; }

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

    public void Validate()
    {
        if (ConfirmAllImportedSegments == true && ConfirmOnlyChangedSegments == true)
        {
            throw new PluginMisconfigurationException(
                "It's only possible to either confirm only changed segments or confirm all imported segments. " +
                "These two values can't be true at the same time"
            );
        }
    }
}
