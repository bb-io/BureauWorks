using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Dtos
{
    public class UuidDto
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}
