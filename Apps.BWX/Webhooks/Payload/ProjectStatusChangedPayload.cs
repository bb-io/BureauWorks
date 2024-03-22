using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Webhooks.Payload
{
    public class ProjectStatusChangedPayload
    {
        public long CreationTimestamp { get; set; }
        public string Creator { get; set; }
        public string CreatorEmail { get; set; }
        public string EventType { get; set; }
        public int Id { get; set; }
        public string Instructions { get; set; }
        public string Name { get; set; }
        public string NewStatus { get; set; }
        public string Notes { get; set; }
        public string PreviousStatus { get; set; }
        public string Reference { get; set; }
        public string SourceLocale { get; set; }
        public string Status { get; set; }
        public List<string> Tags { get; set; }
        public List<string> TargetLocales { get; set; }
        public string Uuid { get; set; }
        public List<string> Workflows { get; set; }
        public List<string> CustomFields { get; set; }
    }
}
