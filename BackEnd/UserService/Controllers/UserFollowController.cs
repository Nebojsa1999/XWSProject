using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Configuration;
using UserService.Models;
using UserService.Models.DTO;
using UserService.Service.Core;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFollowController : BaseController<UserFollows>
    {
        private IUserFollowService userFollowService;
        public IUserService userService;

        public UserFollowController(ProjectConfiguration config, IUserService userService, IUserFollowService userFollowService) : base(config, userService)
        {
            this.userFollowService = userFollowService;
        }

        [Route("follow")]
        [HttpPost]
        public IActionResult Follow(UserFollowDTO userFollowDTO)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(userFollowService.AddUserFollows(userCurrent.Id, userFollowDTO.IdUserWhomFollow));

        }

        [Route("acceptFollow/{userFollowId}")]
        [HttpPut]
        public IActionResult AcceptFollow(long userFollowId)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(userFollowService.AcceptFollow(userFollowId));


        }

        [Route("declineFollow/{userFollowId}")]
        [HttpPut]
        public IActionResult DeclineFollow(long userFollowId)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(userFollowService.DeclineFollow(userFollowId));

        }

        
    }
    }
