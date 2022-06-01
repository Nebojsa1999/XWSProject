using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;

namespace JobService.Repository.Core
{
    public interface IApiKeyRepository : IBaseRepository<ApiKey>
    {
        public IEnumerable<Entity> GetAllApiKeysFromUserId(long userId);

    }
}
