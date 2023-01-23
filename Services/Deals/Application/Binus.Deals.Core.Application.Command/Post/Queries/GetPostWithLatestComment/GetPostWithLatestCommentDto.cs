using System.Collections.Generic;

namespace Binus.Deals.Core.Application.Command.Post.Queries.GetPostWithLatestComment
{
    public class GetPostWithLatestCommentDto
    {
        #region Properties

        public string CreatorName { get; set; }

        public string Caption { get; set; }

        public string ImageUrl { get; set; }
        
        public string CreateDateTime { get; set; }

        public ICollection<PostCommentDto> Comments { get; set; } = new List<PostCommentDto>();

        #endregion
    }
}