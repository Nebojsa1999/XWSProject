using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;
using JobService.Repository.Core;

namespace JobService.Repository
{
   

    public class ApiKeyRepository : BaseRepository<ApiKey>, IApiKeyRepository
    {
        public ApiKeyRepository(ProjectContext context) : base(context)
        {

        }

        public ApiKey GetApiKeyFromUser(long userId)
        {
            return ProjectContext.ApiKeys.Where(x => x.userId == userId).FirstOrDefault();
        }
    }
}
