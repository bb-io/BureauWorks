using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Webhooks.Payload
{
    public class NewUserEvent
    {
        public string Country { get; set; }
        public string EventType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public string Status { get; set; }
        public string Uuid { get; set; }
        public List<string> CustomFields { get; set; }
    }
}
