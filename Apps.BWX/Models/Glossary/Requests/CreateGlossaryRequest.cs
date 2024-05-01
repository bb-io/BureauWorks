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
    public class CreateGlossaryRequest
    {
        public string Name { get; set; }

        [DataSource(typeof(LanguageDataHandler))]
        public List<string> Languages { get; set; }

        [DataSource(typeof(OrganizationDataHandler))]
        public string Organization { get; set; }
        public string? Note { get; set; }
        public string? Domain { get; set; }
        public string? Subdomain { get; set; }

        [Display("Clients")]
        [DataSource(typeof(ClientDataHandler))]
        public List<string>? OrgUnitUUIDs { get; set; }
    }
}
