using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UserService.Configuration;
using UserService.Models;
using UserService.Repository;
using UserService.Service.Core;

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

        public override User Add(User entity)
        {
            if (entity == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);

                entity.Enabled = true;
                unitOfWork.Users.Add(entity);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in AddUserMethod {e.Message} {e.StackTrace}");
                return null;
            }

            return entity;
        }

        public override bool Update(long id, User entity)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                User entity1 = Get(id);
                entity1.Biography = entity.Biography;
                entity1.Education = entity.Education;
                entity1.Email = entity.Email;
                entity1.Gender = entity.Gender;
                entity1.Interest = entity.Interest;
                entity1.Name = entity.Name;
                entity1.PhoneNumber = entity.PhoneNumber;
                entity1.Skill = entity.Skill;
                entity1.Surname = entity.Surname;
                entity1.WorkExperience = entity.WorkExperience;

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

        public IEnumerable<Entity> SearchUser(string userName)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       //poziva dispose na kraju
            {
                return unitOfWork.Users.Search(userName);
            }
        }
    }
}
