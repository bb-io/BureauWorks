using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int TasksCompletedCount { get; set; }
        public string Uuid { get; set; }
    }
}
