using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;
using PostService.Models.Enums;

namespace PostService.Repository.Core
{
    public interface IReactionRepository : IBaseRepository<Reaction>
    {
        public IEnumerable<Reaction> GetReactionsByPost(long postId);
        public IEnumerable<Reaction> GetReactionsByUser(long userId);

        public Reaction GetReactionByUserAndPost(long userId, long postId);
    }
}
