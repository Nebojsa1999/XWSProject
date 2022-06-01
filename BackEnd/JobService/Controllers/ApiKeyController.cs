using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Configuration;
using JobService.Models;
using JobService.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiKeyController : BaseController<ApiKey>
    {
        private IApiKeyService apiKeyService;

        public ApiKeyController(ProjectConfiguration config, IApiKeyService apiKeyService) : base(config)
        {
            this.apiKeyService = apiKeyService;
        }


        [Route("createApiKey")]
        [HttpPost]
        public IActionResult Create(ApiKey apiKey)
        {
            return Ok(apiKeyService.Add(apiKey));
        }

        [Route("getAllApiKeysFromUserId/{userId}")]
        [HttpGet]
        public IActionResult GetAllApiKeysFromUserId(long userId)
        {
            return Ok(apiKeyService.GetApiKeyFromUser(userId));
        }
    }
}
