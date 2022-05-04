using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Configuration;
using UserService.Models;
using UserService.Service;
using UserService.Service.Core;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected BaseService<TEntity> _base;
        protected IUserService _userService;
        protected ProjectConfiguration _config;

        public BaseController(ProjectConfiguration config, IUserService userService)
        {
            _userService = userService;
            _config = config;
            _base = new BaseService<TEntity>(config);
        }

        public BaseController()
        {

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TEntity entity = _base.Get(id);
            if (entity == null)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Add(TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            TEntity response = _base.Add(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            bool response = _base.Update(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool response = _base.Delete(id);
            return Ok(response);
        }

        protected User GetCurrentUser()
        {
            string userName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;
            return _userService.GetUserWithUserName(userName);
        }
    }
}
