using System.Collections.Generic;
using Binus.DealsTourRadar.Core.Domain.AggregateRoots.Post;

namespace Binus.DealsTourRadar.Core.Domain.Dtos.Post
{
    public class PostWithLatestCommentDto
    {
        #region Properties

        public AggregateRoots.Post.Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        
        #endregion
    }
}