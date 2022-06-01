using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Model;
using PostService.Repository.Core;

namespace PostService.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ProjectContext context) : base(context)
        {

        }

        public List<Post> GetPostsPublicUser(List<long> Ids)
        {
            return ProjectContext.Posts.Where(x => Ids.Contains(x.UserId)).ToList();

        }

        public List<Post> GetPostsFromFollowedUser(List<long> Ids)
        {
            return ProjectContext.Posts.Where(x => Ids.Contains(x.UserId)).ToList();

        }

        public List<Post> GetPostsByUser(long userId)
        {
            return ProjectContext.Posts.Where(x => x.UserId == userId).ToList();
        }

       

    }
}
