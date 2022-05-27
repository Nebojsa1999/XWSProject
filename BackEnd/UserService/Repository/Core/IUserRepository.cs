using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository.Core
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithUserName(string userName);
        public IEnumerable<User> GetPublicUsers();
        public IEnumerable<User> GetUsersThatIFollow(long LoggedUserId);
        public IEnumerable<User> GetUsersThatSentRequest(long loggedUserId);
        public IEnumerable<User> GetUsersThatIDontFollow(long loggedUserId);

    }
}
