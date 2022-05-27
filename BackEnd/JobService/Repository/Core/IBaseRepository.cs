using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JobService.Models;

namespace JobService.Repository.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(long Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Detach(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> assert);
        IEnumerable<Entity> Search(string term = "");
        PageResponse<TEntity> GetPage(PageModel pageModel);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> assert);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
