using System.Collections.Generic;
using Binus.Customer.Core.Domain.AggregateRoots.Post;

namespace Binus.Customer.Core.Domain.Dtos.Post
{
    public class PostWithLatestCommentDto
    {
        #region Properties

        public AggregateRoots.Post.Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        
        #endregion
    }
}