using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;

namespace JobService.Service.Core
{
    public interface IJobService : IBaseService<Job>
    {
        public Job AddJob(Job entity, long userId);
        public IEnumerable<Entity> SearchJob(string Position);
        public IEnumerable<Entity> GetAll();
    }
}
