using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;
using PostService.Repository.Core;

namespace PostService.Repository
{
    public class CommentRepository : BaseRepository<Comment> , ICommentRepository
    {
        public CommentRepository(ProjectContext context) : base(context)
        {

        }
        public IEnumerable<Comment> GetCommentsByPost(long postId)
        {
            List<Comment> list = new List<Comment>();
            foreach (Comment comment in ProjectContext.Comments.Where(x => x.PostId == postId).ToList())
            {
                list.Add(comment);
            }

            return list;
        }
    }
}
