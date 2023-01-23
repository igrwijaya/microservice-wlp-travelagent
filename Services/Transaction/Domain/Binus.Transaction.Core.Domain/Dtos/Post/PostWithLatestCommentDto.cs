using System.Collections.Generic;
using Binus.Transaction.Core.Domain.AggregateRoots.Post;

namespace Binus.Transaction.Core.Domain.Dtos.Post
{
    public class PostWithLatestCommentDto
    {
        #region Properties

        public AggregateRoots.Post.Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        
        #endregion
    }
}