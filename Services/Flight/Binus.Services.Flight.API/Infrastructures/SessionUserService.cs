using System.Security.Claims;
using Binus.Flight.Core.Application.Services;
using Microsoft.AspNetCore.Http;

namespace Binus.Services.Flight.API.Infrastructures
{
    public class SessionUserService : ISessionUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Sid);
        
        public string UserEmail => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        public int AccountId
        {
            get
            {
                var sessionAccountId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

                int.TryParse(sessionAccountId, out var accountId);
                
                return accountId;
            }
        }
    }
}