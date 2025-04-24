using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.BWX.Models.Project.Responses;

public class DownloadTranslatedFilesResponse
{
    public DownloadTranslatedFilesResponse()
    {
        TranslatedFiles = new List<FileReference>();
    }

    public List<FileReference> TranslatedFiles { get; set; }
}