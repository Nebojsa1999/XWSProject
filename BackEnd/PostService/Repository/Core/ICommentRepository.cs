using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Model;

namespace PostService.Repository.Core
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        public IEnumerable<Comment> GetCommentsByPost(long postId);
        public IEnumerable<Comment> GetCommentsByUser(long userId);
    }
}
