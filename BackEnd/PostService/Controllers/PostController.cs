using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostService.Configuration;
using PostService.Model;
using PostService.Model.DTO;
using PostService.Service.Core;

namespace PostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController<Post>
    {
        private IPostService postService;

        public PostController(ProjectConfiguration config, IPostService postService) : base(config)
        {
            this.postService = postService;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(PostDTO postDTO)
        {
            
            return Ok(postService.Create(postDTO));
        }

        [Route("getPostsPublicUser")]
        [HttpPost]
        public IActionResult GetPostsPublicUser(ListUserIdDTO listUserIdDTO)
        {
            return Ok(postService.GetPostsPublicUser(listUserIdDTO.UserIds));
        }

        [Route("getPostsFromFollowedUser")]
        [HttpPost]
        public IActionResult GetPostsFromFollowedUser(ListUserIdDTO listUserIdDTO)
        {
            return Ok(postService.GetPostsFromFollowedUser(listUserIdDTO.UserIds));
        }

        [Route("getPostsByUserId/{userId}")]
        [HttpGet]

        public IActionResult GetPostsByUserId(long userId)
        {
            return Ok(postService.GetPostsByUser(userId));
        }


    }
}
