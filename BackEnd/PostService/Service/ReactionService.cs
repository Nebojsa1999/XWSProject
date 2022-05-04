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
        public IEnumerable<Reaction> GetReactionsByPost(long postId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Reactions.GetReactionsByPost(postId);
            }
        }

    }
}
