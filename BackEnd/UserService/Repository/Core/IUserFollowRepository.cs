using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository.Core
{
    public interface IUserFollowRepository : IBaseRepository<UserFollows>
    {
        public UserFollows GetUserFollowBasedOnUsers(long UserWhosFollowsMe, long loggedInUser);
    }
}
