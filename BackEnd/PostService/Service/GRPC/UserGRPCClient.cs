using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace PostService.Service
{
    public class UserGRPCClient
    {
        public UserResponse GetUser(long Id)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:8081");
            var client = new UserGRPC.UserGRPCClient(channel);

            UserRequest request = new UserRequest() { Id = Id };
            UserResponse response = client.GetUser(request);

            return response;
        }
    }
}
