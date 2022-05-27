using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Configuration;
using MessageService.Models;
using MessageService.Repository;
using MessageService.Service.Core;
using Microsoft.Extensions.Logging;

namespace MessageService.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly ILogger _logger;
        protected readonly ProjectConfiguration _configuration;

        public BaseService()
        {

        }

        public BaseService(ProjectConfiguration config)
        {
            _configuration = config;
        }

        public BaseService(ProjectConfiguration config, ILogger<BaseService<TEntity>> logger)
        {
            _configuration = config;
            _logger = logger;
        }

        public virtual TEntity Get(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                TEntity entity = unitOfWork.GetRepository<TEntity>().Get(id);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Get Method {e.Message} in {e.StackTrace}");
                return null;
            }
        }


        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                unitOfWork.GetRepository<TEntity>().Add(entity);
                _ = unitOfWork.Complete();

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Method {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public virtual bool Update(long id, TEntity entity)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                TEntity entity1 = Get(id);

                if (entity1 == null)
                {
                    unitOfWork.GetRepository<TEntity>().Add(entity);
                }

                unitOfWork.GetRepository<TEntity>().Update(entity);
                _ = unitOfWork.Complete();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Update Method {e.Message} in {e.StackTrace}");
                return false;
            }
        }

        public virtual bool Delete(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                TEntity entity = unitOfWork.GetRepository<TEntity>().Get(id);

                unitOfWork.GetRepository<TEntity>().Remove(entity);
                _ = unitOfWork.Complete();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Delete Method { e.Message} in { e.StackTrace}");
                return false;
            }
        }

    }
}
