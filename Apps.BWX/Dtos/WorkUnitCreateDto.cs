using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Dtos
{
    public class WorkUnitCreateDto
    {
        [JsonProperty("projectResourceUuid")]
        public string ProjectResourceUuid { get; set; }

        [JsonProperty("workflows")]
        public List<string> Workflows { get; set; }

        [JsonProperty("targetLocales")]
        public List<string> TargetLocales { get; set; }
    }
}
