using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Model;

namespace PostService.Service.Core
{
    public interface IReactionService : IBaseService<Reaction>
    {
        public IEnumerable<Reaction> GetReactionsByPost(long postId);
        public IEnumerable<Reaction> GetReactionsByUser(long userId);
        public Reaction GetReactionByUserAndPost(long userId, long postId);

    }
}
