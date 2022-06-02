using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;

namespace JobService.Repository.Core
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        public IEnumerable<Entity> SearchJob(string Position);
    }
}
