using System.Threading.Tasks;
using Binus.AccommodationAgoda.Core.Application.Services.Response;

namespace Binus.AccommodationAgoda.Core.Application.Services
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