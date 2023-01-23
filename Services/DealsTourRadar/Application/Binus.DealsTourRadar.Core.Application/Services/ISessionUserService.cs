namespace Binus.DealsTourRadar.Core.Application.Services
{
    public interface ISessionUserService
    {
        #region Properties

        string UserId { get; }
        
        string UserEmail { get; }
        
        int AccountId { get; }

        #endregion

    }
}