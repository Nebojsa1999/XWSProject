using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Configuration;
using MessageService.Models;
using MessageService.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController<Message>
    {
        private IMessageService messageService;

        public MessageController(ProjectConfiguration config, IMessageService messageService) : base(config)
        {
            this.messageService = messageService;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Message message)
        {
            return Ok(messageService.Add(message));
        }
    }
}
