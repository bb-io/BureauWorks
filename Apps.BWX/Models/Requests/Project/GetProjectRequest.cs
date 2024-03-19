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
    public class GetProjectRequest
    {
        [Display("Project ID")]
        [DataSource(typeof(ProjectDataHandler))]
        public string ProjectId { get; set; }
    }
}
