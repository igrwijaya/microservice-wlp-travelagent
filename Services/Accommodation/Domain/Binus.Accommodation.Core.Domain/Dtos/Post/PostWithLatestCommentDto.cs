using System.Collections.Generic;
using Binus.Accommodation.Core.Domain.AggregateRoots.Post;

namespace Binus.Accommodation.Core.Domain.Dtos.Post
{
    public class PostWithLatestCommentDto
    {
        #region Properties

        public AggregateRoots.Post.Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        
        #endregion
    }
}