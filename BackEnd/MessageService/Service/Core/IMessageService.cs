using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;

namespace MessageService.Service.Core
{
    public interface IMessageService : IBaseService<Message>
    {
    }
}
