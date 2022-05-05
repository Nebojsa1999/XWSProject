using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PostService.Configuration;
using PostService.Models;
using PostService.Repository;
using PostService.Service.Core;

namespace PostService.Service
{
    public class ReactionService : BaseService<Reaction>, IReactionService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public ReactionService(ProjectConfiguration configuration, ILogger<ReactionService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public override Reaction Add(Reaction entity)
        {
            if (entity == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                if(unitOfWork.Reactions.GetReactionByUserAndPost(entity.UserId,entity.PostId) != null)
                {
                    return null;
                }
                unitOfWork.Reactions.Add(entity);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in ReactionService in Add {e.Message} {e.StackTrace}");
                return null;
            }

            return entity;
        }
        public IEnumerable<Reaction> GetReactionsByPost(long postId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Reactions.GetReactionsByPost(postId);
            }
        }
        public IEnumerable<Reaction> GetReactionsByUser(long userId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Reactions.GetReactionsByUser(userId);
            }
        }

     

    }
}
