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
    public class UserController : BaseController<User>
    {
        private IUserService userService;

        public UserController(ProjectConfiguration config, IUserService userService) : base(config, userService)
        {
            this.userService = userService;

        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (userService.GetUserWithUserName(user.Username) != null)
            {
                return BadRequest("UserName already exists");
            }
            
            return Ok(userService.Add(user));
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search(SearchDTO searchDTO)
        {
            return Ok(userService.SearchUser(searchDTO.UserName));
        }

        [Route("updateProfile")]
        [HttpPut]

        public IActionResult UpdateProfile(User user)
        {
            if (userService.GetUserWithUserName(user.Username) != null)
            {
                return BadRequest("UserName already exists");
            }
            User userCurrent = GetCurrentUser();
            if(userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }
            return Ok(userService.Update(userCurrent.Id,user));
        }

        [Route("getPublicUsers")]
        [HttpGet]
        public IActionResult GetPublicUsers()
        {
            return Ok(userService.GetPublicUsers());
        }

        [Route("getUsersThatIFollow")]
        [HttpGet]
        public IActionResult GetUsersThatIFollow()
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(userService.GetUsersThatIFollow(userCurrent.Id));
        }

     
    }
}
