using System.Collections.Generic;
using System.Threading.Tasks;
using IGR.Core.Domain.Commons;
using IGR.Core.Domain.Dtos.Post;

namespace IGR.Core.Domain.AggregateRoots.Post
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        #region Public Methods

        Task<IEnumerable<PostWithLatestCommentDto>> GetWithCommentsAsync(int startIndex, int length);

        Task DeletePostAsync(int accountId);

        #endregion
    }
}