using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.BWX.Models.Project.Responses;

public class DownloadTranslatedFilesResponse
{
    [Display("Translated files")]
    public List<FileWithLanguagesResponse> TranslatedFiles { get; set; } = new();
}

public class FileWithLanguagesResponse
{
    [Display("Source language")]
    public string SourceLanguage { get; set; } = string.Empty;

    [Display("Target language")]
    public string TargetLanguage { get; set; } = string.Empty;

    [Display("File")]
    public FileReference File { get; set; } = new();
}