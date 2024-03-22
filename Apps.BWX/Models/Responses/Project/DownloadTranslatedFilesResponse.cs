using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Models.Responses.Project
{
    public class DownloadTranslatedFilesResponse
    {
        public DownloadTranslatedFilesResponse() 
        {
            TranslatedFiles = new List<FileReference>();
        }


        [Display("Translated files")]
        public List<FileReference> TranslatedFiles { get; set; }
    }
}
