using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Models
{
    public class ApiKey : Entity
    {
        public string ApiKeyString { get; set; }
        public long userId { get; set; }

    }
}
