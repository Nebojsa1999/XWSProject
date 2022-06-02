using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;
using JobService.Repository;
using JobService.Service.Core;
using Microsoft.Extensions.Logging;

namespace JobService.Service
{
    public class JobService : BaseService<Job>, IJobService
    {
        public  Job AddJob(Job entity,long userId)
        {
            if (entity == null)
            {
                return null;
            }
            Job job = new Job();
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                job.Description = entity.Description;
                job.DescriptionActivity = entity.DescriptionActivity;
                job.Position = entity.Position;
                job.Precondition = entity.Precondition;
                job.OwnerId = userId;
                unitOfWork.Jobs.Add(job);
                _ = unitOfWork.Complete();


                return entity;

            }



            catch (Exception e)
            {
                _logger.LogError($"Error in JobService in AddJob {e.Message} {e.StackTrace}");
                return null;
            }
        }

        public IEnumerable<Entity> SearchJob(string Position)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {
                return unitOfWork.Jobs.SearchJob(Position);
            }
        }

        public IEnumerable<Entity> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {
                return unitOfWork.Jobs.GetAll();
            }
        }
    }
}
