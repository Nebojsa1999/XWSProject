using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Models
{
    public class Job : Entity
    {
        public string Description { get; set; }
        public string Position { get; set; }
        public string DescriptionActivity { get; set; }
        public string Precondition { get; set; }
    }
}
