using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;
using MessageService.Repository.Core;

namespace MessageService.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ProjectContext context) : base(context)
        {

        }
    
    }
}
