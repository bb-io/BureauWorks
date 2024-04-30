using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.BWX.Models.Responses.Project;

public class DownloadTranslatedFilesResponse
{
    public DownloadTranslatedFilesResponse() 
    {
        TranslatedFiles = new List<FileReference>();
    }


    [Display("Translated files")]
    public List<FileReference> TranslatedFiles { get; set; }
}