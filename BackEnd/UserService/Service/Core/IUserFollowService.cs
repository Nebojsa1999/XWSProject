using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Service.Core
{
    public interface IUserFollowService : IBaseService<UserFollows>
    {
        UserFollows AddUserFollows(long UserWhoFollowsID, long UserWhomFollowsID);
        public bool AcceptFollow(long userWhoFollowsMe, long loggedInUser);
        public bool DeclineFollow(long userWhoFollowsMe, long loggedInUser);

    }
}
