using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;
using UserService.Models.DTO;

namespace UserService.Service.Core
{
    public interface IUserService :  IBaseService<User>
    {
        User GetUserWithUserName(string userName);
        User AddUser(RegisterDTO entity);
        public bool UpdateUser(long id, UpdateDTO entity);
        public IEnumerable<User> GetAllUsers();
        IEnumerable<Entity> SearchUser(string term="");
        public IEnumerable<User> GetPublicUsers();
        public IEnumerable<User> GetUsersThatIFollow(long UserLoggedId);
        public IEnumerable<User> GetUsersThatSentRequest(long UserLoggedId);
        public IEnumerable<User> GetUsersThatIDontFollow(long UserLoggedId);

    }

}
