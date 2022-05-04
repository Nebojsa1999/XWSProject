using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;
using PostService.Models.Enums;
using PostService.Repository.Core;

namespace PostService.Repository
{
    public class ReactionRepository : BaseRepository<Reaction>, IReactionRepository
    {
        public ReactionRepository(ProjectContext context) : base(context)
        {

        }
        public IEnumerable<Reaction> GetReactionsByPost(long postId)
        {
            List<Reaction> list = new List<Reaction>();
            foreach (Reaction reaction in ProjectContext.Reactions.Where(x => x.PostId == postId).ToList())
            {
                list.Add(reaction);
            }

            return list;
        }

        public IEnumerable<Reaction> CheckIfReactionExists(long userId,long postId,EnumReaction reaction )
        {
           return ProjectContext.Reactions.Where(x => x.PostId == postId && x.UserId == userId && x.Reactions == reaction).ToList();
        }
    }
}
