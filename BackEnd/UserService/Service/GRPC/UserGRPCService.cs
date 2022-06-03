using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using UserService.Models;
using UserService.Repository.Core;

namespace UserService.Service.GRPC
{
    public class UserGRPCService : UserGRPC.UserGRPCBase
    {
        private IUserRepository userRepository;

        public UserGRPCService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override Task<UserResponse> GetUser(UserRequest request, ServerCallContext context)
        {
            User user = userRepository.Get(request.Id);

            return Task.FromResult(
                new UserResponse() { FirstName = user.Name, LastName = user.Surname, Id = user.Id }
                ); ;
        }
    }
}
