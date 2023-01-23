using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.Partner.Core.Domain.Commons;
using Binus.Partner.Core.Domain.Dtos.Post;

namespace Binus.Partner.Core.Domain.AggregateRoots.Post
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        #region Public Methods

        Task<IEnumerable<PostWithLatestCommentDto>> GetWithCommentsAsync(int startIndex, int length);

        Task DeletePostAsync(int accountId);

        #endregion
    }
}