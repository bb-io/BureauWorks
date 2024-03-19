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
    public class CreateProjectRequest
    {
        public string Reference { get; set; }
        public string OrgUnitUUID { get; set; }
        public string ContactUUID { get; set; }

        [Display("Source locale")]
        [DataSource(typeof(LanguageDataHandler))]
        public string SourceLocale { get; set; }
        public string Notes { get; set; }
        public string Timezone { get; set; }
        public string Currency { get; set; }
        public List<object> Tags { get; set; }

        [Display("Infer default settings", Description = "Set \"true\" to automatically infer the default settings of a project based on its Organizational unit's settings, such as price list, currency, autopilot, and so on.")]
        public bool? InferDefaultSettings { get; set; }
    }
}
