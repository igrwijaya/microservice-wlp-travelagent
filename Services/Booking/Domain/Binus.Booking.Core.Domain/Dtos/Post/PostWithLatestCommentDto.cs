using System.Collections.Generic;
using Binus.Booking.Core.Domain.AggregateRoots.Post;

namespace Binus.Booking.Core.Domain.Dtos.Post
{
    public class PostWithLatestCommentDto
    {
        #region Properties

        public AggregateRoots.Post.Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        
        #endregion
    }
}