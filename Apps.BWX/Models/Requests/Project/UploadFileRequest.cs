using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Models.Requests.Project
{
    public class UploadFileRequest
    {
        public FileReference File { get; set; }

        [Display("File name", Description = "Override file name")]
        public string? FileName { get; set; }

        [Display("File path", Description = "Override file path")]
        public string? FilePath { get; set; }
        public string? Notes { get; set; }
    }
}
