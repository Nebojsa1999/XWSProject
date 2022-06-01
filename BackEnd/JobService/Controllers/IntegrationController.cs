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
    public class IntegrationController : BaseController<Job>
    {
        private IJobService jobService;

        public IntegrationController(ProjectConfiguration config, IJobService jobService) : base(config)
        {
            this.jobService = jobService;
        }

    }
}
