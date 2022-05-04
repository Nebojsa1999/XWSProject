using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service.Core
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Get(long id);
        TEntity Add(TEntity entity);
        bool Update(long id, TEntity entity);
        bool Delete(long id);

    }
}
