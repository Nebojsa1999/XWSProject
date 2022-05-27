using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Models
{
    public class Message : Entity
    {
        public long UserIdSender { get; set; }
        public long UserIdReceiver { get; set; }
        public string Content { get; set; }
    }
}
