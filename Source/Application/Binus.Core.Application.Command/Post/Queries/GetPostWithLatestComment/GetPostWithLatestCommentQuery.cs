using System.Collections.Generic;
using Binus.Core.Application.Commons;
using MediatR;

namespace Binus.Core.Application.Command.Post.Queries.GetPostWithLatestComment
{
    public class GetPostWithLatestCommentQuery : IRequest<BaseQueryResult<List<GetPostWithLatestCommentDto>>>
    {
        #region Properties

        public int StartIndex { get; set; }

        public int Length { get; set; }

        #endregion
    }
}