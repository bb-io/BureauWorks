﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Dtos
{
    public class ExportInitDto
    {
        [JsonProperty("requestUuid")]
        public string RequestUuid { get; set; }
        public string Status { get; set; }
    }
}
