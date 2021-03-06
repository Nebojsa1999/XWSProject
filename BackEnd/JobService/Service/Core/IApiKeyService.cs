using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;

namespace JobService.Service.Core
{
    public interface IApiKeyService : IBaseService<ApiKey>
    {
        public ApiKey GetApiKeyFromUser(long id);
        public ApiKey CheckIfApiKeyExists(string api);
    }
}
