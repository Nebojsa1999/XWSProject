using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PostService.Configuration;
using PostService.Models;
using PostService.Service.Core;

namespace PostService.Service
{
    public class CommentService  : BaseService<Comment>, ICommentService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public CommentService(ProjectConfiguration configuration, ILogger<CommentService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
    }
}
