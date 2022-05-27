using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PostService.Configuration;
using PostService.Model;
using PostService.Model.DTO;
using PostService.Repository;
using PostService.Service.Core;

namespace PostService.Service
{
    public class PostService : BaseService<Post>, IPostService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public PostService(ProjectConfiguration configuration, ILogger<PostService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public Post Create(PostDTO postDTO)
        {
            try
            {

                Post post = new Post();

                using UnitOfWork unitOfWork = new(new ProjectContext());
                unitOfWork.Posts.Add(post);
                unitOfWork.Complete();
                unitOfWork.Posts.Update(post);
                post.Content = postDTO.Content;
                post.Link = postDTO.Link;
                post.Image = postDTO.Image;
                post.UserId = postDTO.UserId;
                _ = unitOfWork.Complete();
                return post;
            }

            catch(Exception e)
            {
                _logger.LogError($"Error in Create in PostService {e.Message} {e.StackTrace}");
                return null;
            }

         } 
        
        public List<Post> GetPostsPublicUser(List<long> listUserIdDTO)
        
        {
            using UnitOfWork unitOfWork = new(new ProjectContext());
            {
             return unitOfWork.Posts.GetPostsPublicUser(listUserIdDTO);
            }
        }
        public List<Post> GetPostsFromFollowedUser(List<long> listUserIdDTO)

        {
            using UnitOfWork unitOfWork = new(new ProjectContext());
            {
                return unitOfWork.Posts.GetPostsFromFollowedUser(listUserIdDTO);
            }
        }

   
    }

}
