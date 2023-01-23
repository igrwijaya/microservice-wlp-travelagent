using System.Collections.Generic;
using Binus.ActivitiesVendor.Core.Application.Commons;
using MediatR;

namespace Binus.ActivitiesVendor.Core.Application.Command.Post.Queries.GetPostWithLatestComment
{
    public class GetPostWithLatestCommentQuery : IRequest<BaseQueryResult<List<GetPostWithLatestCommentDto>>>
    {
        #region Properties

        public int StartIndex { get; set; }

        public int Length { get; set; }

        #endregion
    }
}