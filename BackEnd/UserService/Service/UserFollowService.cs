using System;
using Microsoft.Extensions.Logging;
using UserService.Configuration;
using UserService.Models;
using UserService.Repository;
using UserService.Service.Core;

namespace UserService.Service
{
    public class UserFollowService : BaseService<UserFollows>, IUserFollowService
    {
        public IUserService userService;
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public UserFollowService(ProjectConfiguration configuration, ILogger<Userservice> logger,IUserService userservice)
        {
            _logger = logger;
            _configuration = configuration;
            this.userService = userservice;
        }

        public UserFollows AddUserFollows(long UserWhoFollowsID, long UserWhomFollowsID)
        {
            try
            {

                UserFollows userFollows = new UserFollows();
                User userWhich = userService.Get(UserWhoFollowsID);
                User userWhom = userService.Get(UserWhomFollowsID);

                using UnitOfWork unitOfWork = new(new ProjectContext());
                unitOfWork.UserFollows.Add(userFollows);
                unitOfWork.Complete();

                if (userWhom.Privacy == true)
                {
                    unitOfWork.UserFollows.Update(userFollows);
                    userFollows.UserWhich = userWhich;
                    userFollows.UserWhom = userWhom;
                    userFollows.StateOfFollow = Models.Enum.UserFollowEnum.Pending;
                    _ = unitOfWork.Complete();
                }
                else if (userWhom.Privacy == false)
                {
                    unitOfWork.UserFollows.Update(userFollows);
                    userFollows.UserWhich = userWhich;
                    userFollows.UserWhom = userWhom;
                    userFollows.StateOfFollow = Models.Enum.UserFollowEnum.Accepted;
                    _ = unitOfWork.Complete();


                }
                return userFollows;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserFollowService in AddUserFollows {e.Message} {e.StackTrace}");
                return null;
            }

        }

        public UserFollows GetUserFollowBasedOnUsers(long UserWhoFollowsID, long UserWhomFollowsID)
        {

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                return unitOfWork.UserFollows.GetUserFollowBasedOnUsers(UserWhoFollowsID, UserWhomFollowsID);
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserFollowService in GetUserFollowBasedOnUsers {e.Message } in { e.StackTrace}");
                return null;
            }
        }
         
        public bool AcceptFollow(long userWhoFollowsMe, long loggedInUser)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                UserFollows userFollows = GetUserFollowBasedOnUsers(userWhoFollowsMe, loggedInUser);
                userFollows.StateOfFollow = Models.Enum.UserFollowEnum.Accepted;
                unitOfWork.UserFollows.Update(userFollows);
                _ = unitOfWork.Complete();
                return true;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserFollowService in AcceptFollow Method {e.Message} in {e.StackTrace}");
                return false;
            }
        }

        public bool DeclineFollow(long userWhoFollowsMe, long loggedInUser)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                UserFollows userFollows = GetUserFollowBasedOnUsers(userWhoFollowsMe, loggedInUser);
                userFollows.StateOfFollow = Models.Enum.UserFollowEnum.Declined;
                unitOfWork.UserFollows.Update(userFollows);
                _ = unitOfWork.Complete();
                return true;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserFollowService in DeclineFollow Method {e.Message} in {e.StackTrace}");
                return false;
            }
        }


    }

}
