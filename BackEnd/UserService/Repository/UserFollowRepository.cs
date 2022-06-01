using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Repository.Core;

namespace UserService.Repository
{
    public class UserFollowRepository : BaseRepository<UserFollows>, IUserFollowRepository
    {
        public UserFollowRepository(ProjectContext context) : base(context)
        {
          
        }

        public UserFollows GetUserFollowBasedOnUsers(long UserWhosFollowsMe, long loggedInUser)
        {
            return ProjectContext.UserFollows.Where(x => x.UserWhom.Id == loggedInUser && x.UserWhich.Id == UserWhosFollowsMe).Include(x => x.UserWhich).Include(x => x.UserWhom).FirstOrDefault();
        }
    }
}
