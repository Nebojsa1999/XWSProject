using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;
using UserService.Repository.Core;

namespace UserService.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {

        }

        public User GetUserWithUserName(string userName)
        {
            return ProjectContext.Users.Where(x => x.Username == userName).FirstOrDefault();
        }

        public override IEnumerable<Entity> Search(string term = "")
        {
            return ProjectContext.Users.Where(x => x.Username.Contains(term) && x.Privacy == false).ToList();
        }

        public IEnumerable<User> GetPublicUsers()
        {
            return ProjectContext.Users.Where(x=>x.Privacy ==false).ToList();
        }

    }

}
