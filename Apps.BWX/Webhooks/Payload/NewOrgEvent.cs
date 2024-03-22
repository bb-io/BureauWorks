using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Webhooks.Payload
{
    public class NewOrgEvent
    {
        public string Country { get; set; }
        public string EventType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uuid { get; set; }
        public List<string> CustomFields { get; set; }
    }
}
