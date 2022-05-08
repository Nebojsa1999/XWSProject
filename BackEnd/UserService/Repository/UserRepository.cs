using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Models.Enum;
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

        public IEnumerable<User> GetUsersThatIFollow(long loggedUserId)
        {
            List<User> list = new List<User>();
            foreach (UserFollows entity in ProjectContext.UserFollows.Where(x => x.UserWhich.Id == loggedUserId && x.StateOfFollow == UserFollowEnum.Accepted).Include(x=>x.UserWhom).Include(x=>x.UserWhich).ToList())
            {
                list.Add(entity.UserWhom);
            }

            return list;
        }

        public IEnumerable<User> GetUsersThatSentRequest(long loggedUserId)
        {
            List<User> list = new List<User>();
            foreach (UserFollows entity in ProjectContext.UserFollows.Where(x => x.UserWhom.Id == loggedUserId && x.StateOfFollow == UserFollowEnum.Pending).Include(x => x.UserWhom).Include(x => x.UserWhich).ToList())
            {
                list.Add(entity.UserWhich);
            }

            return list;
        }

    }

}
