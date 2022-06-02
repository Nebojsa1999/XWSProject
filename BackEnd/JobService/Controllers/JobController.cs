using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Configuration;
using JobService.Models;
using JobService.Models.DTO;
using JobService.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController<Job>
    {
        private IJobService jobService;

        public JobController(ProjectConfiguration config, IJobService jobService) : base(config)
        {
            this.jobService = jobService;
        }

       [Route("searchjob")]
       [HttpPost]
       public IActionResult Search(SearchDTO searchDTO)
        {
            return Ok(jobService.SearchJob(searchDTO.Position));
        }

        [Route("getAllJobs")]
        [HttpGet]
        public IActionResult GetAllJobs()
        {
            return Ok(jobService.GetAll());
        }


    }
}
