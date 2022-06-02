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
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                ApiKey apiKey = GetApiKeyFromUser(entity.userId);

                if (apiKey == null)
                {

                    unitOfWork.ApiKeys.Add(entity);
                    _ = unitOfWork.Complete();

                }

                else
                {
                    apiKey.ApiKeyString = RandomStringHelper.RandomString(5);
                    unitOfWork.ApiKeys.Update(apiKey);
                    _ = unitOfWork.Complete();
                }
                return entity;

            }



            catch (Exception e)
            {
                _logger.LogError($"Error in ApiKeyService in Add {e.Message} {e.StackTrace}");
                return null;
            }
        }
        public ApiKey GetApiKeyFromUser(long id)
        {

            using UnitOfWork unitOfWork = new(new ProjectContext());
            return unitOfWork.ApiKeys.GetApiKeyFromUser(id);
        }

        public ApiKey CheckIfApiKeyExists(string api)
        {
            using UnitOfWork unitOfWork = new(new ProjectContext());
            return unitOfWork.ApiKeys.CheckIfApiKeyExists(api);
        }


 
    }
}
