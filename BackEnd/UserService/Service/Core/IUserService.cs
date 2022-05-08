using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Service.Core
{
    public interface IUserService :  IBaseService<User>
    {
        User GetUserWithUserName(string userName);
        User Add(User entity);
        IEnumerable<Entity> SearchUser(string term="");
        public IEnumerable<User> GetPublicUsers();
        public IEnumerable<User> GetUsersThatIFollow(long UserLoggedId);
        public IEnumerable<User> GetUsersThatSentRequest(long UserLoggedId);

    }

}
