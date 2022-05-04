using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;
using PostService.Models.DTO;

namespace PostService.Service.Core
{
    public interface IPostService : IBaseService<Post>
    {
        public Post Create(PostDTO postDTO);
        public List<Post> GetPostsPublicUser(List<long> listUserIdDTO);

    }
}
