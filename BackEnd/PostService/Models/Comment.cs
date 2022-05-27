using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public long UserId { get; set; }
        public long PostId { get; set; }
    }
}
