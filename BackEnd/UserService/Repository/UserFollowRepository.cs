using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;
using UserService.Repository.Core;

namespace UserService.Repository
{
    public class UserFollowRepository : BaseRepository<UserFollows>, IUserFollowRepository
    {
        public UserFollowRepository(ProjectContext context) : base(context)
        {
            
        }
    }
}
