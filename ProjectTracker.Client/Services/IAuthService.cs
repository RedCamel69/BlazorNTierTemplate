using ProjectTracker.Shared.Models.Account;

namespace ProjectTracker.Client.Services
{
    public interface IAuthService
    {
        Task Register(AccountRegistrationRequest request);
    }
}
