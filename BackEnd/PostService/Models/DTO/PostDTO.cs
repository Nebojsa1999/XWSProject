using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model.DTO
{
    public class PostDTO
    {
        public string Content { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public long UserId { get; set; }
    }
}
