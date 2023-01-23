using System.Threading.Tasks;
using IGR.Core.Application.Services.Response;

namespace IGR.Core.Application.Services
{
    public interface IIdentityService
    {
        #region Public Methods

        Task<IdentityResponse> CreateAsync(int accountId, string email, string password);

        Task<IdentityResponse> LoginAsync(string email, string password);

        Task DeleteAsync(string userId);

        #endregion
    }
}