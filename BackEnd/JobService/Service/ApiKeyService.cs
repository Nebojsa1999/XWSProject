using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;
using JobService.Repository;
using JobService.Service.Core;
using JobService.Util;
using Microsoft.Extensions.Logging;

namespace JobService.Service
{
    public class ApiKeyService : BaseService<ApiKey>, IApiKeyService
    {
        public override ApiKey Add(ApiKey entity)
        {
            if (entity == null)
            {
                return null;
            }
            ApiKey apiKey = new ApiKey();

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());

                apiKey.ApiKeyString = RandomStringHelper.RandomString(5);
                apiKey.userId = entity.userId;
                unitOfWork.ApiKeys.Add(apiKey);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in ApiKey in Add Method {e.Message} {e.StackTrace}");
                return null;
            }

            return apiKey;
        }

        public IEnumerable<Entity> GetAllApiKeysFromUserId(long userId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       //poziva dispose na kraju
            {
                return unitOfWork.ApiKeys.GetAllApiKeysFromUserId(userId);
            }
        }
    }
}
