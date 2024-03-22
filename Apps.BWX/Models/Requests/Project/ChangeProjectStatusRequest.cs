using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Models.Requests.Project
{
    public class ChangeProjectStatusRequest
    {
        [Display("Project status")]
        [DataSource(typeof(ProjectStatusDataHandler))]
        public string ProjectStatus { get; set; }

        public string Reason { get; set; }
    }
}
