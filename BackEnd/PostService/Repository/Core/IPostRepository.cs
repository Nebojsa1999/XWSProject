using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;

namespace PostService.Repository.Core
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public List<Post> GetPostsPublicUser(List<long> listUserIdDTO);
        public List<Post> GetPostsFromFollowedUser(List<long> Ids);
    }
}
