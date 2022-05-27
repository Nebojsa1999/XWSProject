using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Models.DTO
{
    public class ReactionByUserAndPostDTO
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
    }
}
