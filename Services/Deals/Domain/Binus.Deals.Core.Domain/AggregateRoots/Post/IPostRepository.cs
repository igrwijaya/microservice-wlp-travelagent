using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.Deals.Core.Domain.Commons;
using Binus.Deals.Core.Domain.Dtos.Post;

namespace Binus.Deals.Core.Domain.AggregateRoots.Post
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        #region Public Methods

        Task<IEnumerable<PostWithLatestCommentDto>> GetWithCommentsAsync(int startIndex, int length);

        Task DeletePostAsync(int accountId);

        #endregion
    }
}