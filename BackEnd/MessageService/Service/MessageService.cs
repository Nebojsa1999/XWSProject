using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;
using MessageService.Service.Core;

namespace MessageService.Service
{
    public class MessageService : BaseService<Message>, IMessageService
    {
    }
}
