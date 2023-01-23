using System.Collections.Generic;
using Binus.DealsTourRadar.Core.Application.Commons;
using MediatR;

namespace Binus.DealsTourRadar.Core.Application.Command.Post.Queries.GetPostWithLatestComment
{
    public class GetPostWithLatestCommentQuery : IRequest<BaseQueryResult<List<GetPostWithLatestCommentDto>>>
    {
        #region Properties

        public int StartIndex { get; set; }

        public int Length { get; set; }

        #endregion
    }
}