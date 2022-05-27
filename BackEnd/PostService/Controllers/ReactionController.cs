using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostService.Configuration;
using PostService.Model;
using PostService.Models.DTO;
using PostService.Service.Core;

namespace PostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : BaseController<Reaction>
    {
        private IReactionService reactionService;

        public ReactionController(ProjectConfiguration config, IReactionService reactionService) : base(config)
        {
            this.reactionService = reactionService;
        }

        [Route("postReaction")]
        [HttpPost]
        public IActionResult PostReaction(Reaction reaction)
        {
            return Ok(reactionService.Add(reaction));
        }
        [Route("getReactionsByPost/{postId}")]
        [HttpGet]
        public IActionResult GetReactionsByPost(long postId)
        {
            return Ok(reactionService.GetReactionsByPost(postId));
        }
        [Route("getReactionsByUser/{userId}")]
        [HttpGet]
        public IActionResult GetReactionsByUser(long userId)
        {
            return Ok(reactionService.GetReactionsByUser(userId));
        }

        [Route("getReactionByUserAndPost")]
        [HttpPost]
        public IActionResult GetReactionByUserAndPost(ReactionByUserAndPostDTO reactionByUserAndPostDTO)
        {
            return Ok(reactionService.GetReactionByUserAndPost(reactionByUserAndPostDTO.UserId, reactionByUserAndPostDTO.PostId));

        }

    }
}
