using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Configuration;
using MessageService.Service;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected BaseService<TEntity> _base;
        protected ProjectConfiguration _config;

        public BaseController(ProjectConfiguration config)
        {
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
    }
}
