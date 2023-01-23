using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.Flight.Core.Domain.Commons;
using Binus.Flight.Core.Domain.Dtos.Post;

namespace Binus.Flight.Core.Domain.AggregateRoots.Post
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        #region Public Methods

        Task<IEnumerable<PostWithLatestCommentDto>> GetWithCommentsAsync(int startIndex, int length);

        Task DeletePostAsync(int accountId);

        #endregion
    }
}