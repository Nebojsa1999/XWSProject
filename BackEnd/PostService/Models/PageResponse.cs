using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class PageResponse<TEntity> where TEntity : class

    {
        public int TotalNumber { get; set; }
        public IEnumerable<TEntity> Entities { get; set; }

        public PageResponse(IEnumerable<TEntity> entities, int totalNumber)
        {
            Entities = entities;
            TotalNumber = totalNumber;
        }
    }
}
