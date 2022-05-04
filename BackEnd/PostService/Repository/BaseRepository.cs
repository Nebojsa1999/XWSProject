using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostService.Models;
using PostService.Repository.Core;

namespace PostService.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        public ProjectContext ProjectContext
        {
            get { return DbContext as ProjectContext; }
        }

        public BaseRepository(DbContext dbcontext)
        {
            DbContext = dbcontext;
        }

        public virtual TEntity Get(long Id)
        {
            return DbContext.Set<TEntity>().Find(Id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }
        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }
        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Detach(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Detached;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> assert)
        {
            return DbContext.Set<TEntity>().Where(assert);
        }

        public virtual IEnumerable<Entity> Search(string term = "")
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }
        public virtual PageResponse<TEntity> GetPage(PageModel pageModel)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> assert)
        {
            return DbContext.Set<TEntity>().SingleOrDefault(assert);
        }

       
    }
}
