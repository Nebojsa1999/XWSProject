using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UserService.Configuration;
using UserService.Models;
using UserService.Models.DTO;
using UserService.Repository;
using UserService.Service.Core;
using UserService.Util;

namespace UserService.Service
{
    public class Userservice : BaseService<User>, IUserService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public Userservice(ProjectConfiguration configuration, ILogger<Userservice> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public  User AddUser(RegisterDTO entity)
        {
            if (entity == null)
            {
                return null;
            }
            User user = new User();

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                user.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);

                user.Enabled = true;
                user.Gender = ParseHelper.genderString(entity.Gender);
                user.Email = entity.Email;
                user.Username = entity.Username;
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.PhoneNumber = entity.PhoneNumber;
                user.DateOfBirth = DateTime.Parse(entity.DateOfBirth);
                unitOfWork.Users.Add(user);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in AddUserMethod {e.Message} {e.StackTrace}");
                return null;
            }

            return user;
        }

        public bool UpdateUser(long id, UpdateDTO entity)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                User entity1 = Get(id);
                entity1.Biography = entity.Biography;
                entity1.Education = entity.Education;
                entity1.Email = entity.Email;
                entity1.Gender = ParseHelper.genderInt(entity.Gender);
                entity1.Interest = entity.Interest;
                entity1.Name = entity.Name;
                entity1.PhoneNumber = entity.PhoneNumber;
                entity1.Skill = entity.Skill;
                entity1.Surname = entity.Surname;
                entity1.WorkExperience = entity.WorkExperience;
                entity1.DateOfBirth = DateTime.Parse(entity.DateOfBirth);
                entity1.Privacy = entity.Privacy;
                unitOfWork.Users.Update(entity1);
                _ = unitOfWork.Complete();
                return true;

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Update Method {e.Message} in {e.StackTrace}");
                return false;
            }



        }

        public User GetUserWithUserName(string userName)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                return unitOfWork.Users.GetUserWithUserName(userName);
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in GetUserWithEmailMethod {e.Message } in { e.StackTrace}");
                return null;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       //poziva dispose na kraju
            {
                return unitOfWork.Users.GetAll();
            }
        }

        public IEnumerable<User> GetPublicUsers()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {
                return unitOfWork.Users.GetPublicUsers();
            }
        }

        public IEnumerable<User> GetUsersThatIFollow(long UserLoggedId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Users.GetUsersThatIFollow(UserLoggedId);
            }
        }

        public IEnumerable<User> GetUsersThatSentRequest(long UserLoggedId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Users.GetUsersThatSentRequest(UserLoggedId);
            }
        }

        public IEnumerable<User> GetUsersThatIDontFollow(long UserLoggedId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Users.GetUsersThatIDontFollow(UserLoggedId);
            }
        }


        public IEnumerable<Entity> SearchUser(string Name)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       //poziva dispose na kraju
            {
                return unitOfWork.Users.Search(Name);
            }
        }
    }
}
