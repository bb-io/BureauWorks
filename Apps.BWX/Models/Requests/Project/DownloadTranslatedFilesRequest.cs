using Apps.BWX.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Models.Requests.Project
{
    public class DownloadTranslatedFilesRequest
    {
        [DataSource(typeof(ProjectResourcesDataHandler))]
        public List<string>? Resources { get; set; }

        [Display("Locales")]
        [DataSource(typeof(LanguageDataHandler))]
        public List<string>? Locales { get; set; }
    }
}
