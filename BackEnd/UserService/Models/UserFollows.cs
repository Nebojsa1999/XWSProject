using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models.Enum;

namespace UserService.Models
{
    public class UserFollows : Entity
    {
        public User UserWhich { get; set; } //koji user prati
        public User UserWhom { get; set; } //koga prati
        public UserFollowEnum StateOfFollow {get; set;}
    }
}
