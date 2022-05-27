using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Model.Enums;

namespace PostService.Model
{
    public class Reaction : Entity
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
        public EnumReaction Reactions { get; set; }
    }
}
