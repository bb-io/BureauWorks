using Apps.BWX.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Models.Glossary.Requests
{
    public class ExportGlossaryRequest
    {
        [Display("Glossary")]
        [DataSource(typeof(GlossaryDataHandler))]
        public string GlossaryId { get; set; }
    }
}
