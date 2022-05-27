using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;
using JobService.Service.Core;

namespace JobService.Service
{
    public class JobService : BaseService<Job>, IJobService
    {
    }
}
