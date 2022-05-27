using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostService.Configuration;
using PostService.Model;
using PostService.Service.Core;

namespace PostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController<Comment>
    {
        private ICommentService commentService;

        public CommentController(ProjectConfiguration config, ICommentService commentService) : base(config)
        {
            this.commentService = commentService;
        }

        [Route("postComment")]
        [HttpPost]
        public IActionResult PostComment(Comment comment)
        {
            return Ok(commentService.Add(comment));
        }
        [Route("getCommentsByPost/{postId}")]
        [HttpGet]
        public IActionResult GetCommentsByPost(long postId)
        {
            return Ok(commentService.GetCommentsByPost(postId));
        }
        [Route("getCommentsByUser/{postId}")]
        [HttpGet]
        public IActionResult GetCommentsByUser(long userId)
        {
            return Ok(commentService.GetCommentsByUser(userId));
        }
    }
}
