using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Dtos
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
