using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;
using JobService.Repository.Core;

namespace JobService.Repository
{
    public class JobRepostiory: BaseRepository<Job>, IJobRepository
    {
        public JobRepostiory(ProjectContext context) : base(context)
        {

        }

        public  IEnumerable<Entity> SearchJob(string Position)
        {
            return ProjectContext.Jobs.Where(x => x.Position.Contains(Position)).ToList();
        }


    }
}
