using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Webhooks.Payload
{
    public class ProjectTranslationFinishedEvent
    {
        public int ProjectId { get; set; }
        public string ProjectUuid { get; set; }
        public string ProjectName { get; set; }
        public int TotalWorkUnitsCompleted { get; set; }
        public int TotalWorkUnitsFailed { get; set; }
        public int TotalWorkUnits { get; set; }
        public string EventType { get; set; }
    }
}
