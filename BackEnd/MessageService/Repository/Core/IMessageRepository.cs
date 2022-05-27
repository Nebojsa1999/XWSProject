using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;

namespace MessageService.Repository.Core
{
    public interface IMessageRepository : IBaseRepository<Message>
   
    {
    }
}
