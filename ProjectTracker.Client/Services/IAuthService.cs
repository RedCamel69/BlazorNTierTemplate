using ProjectTracker.Shared.Models.Account;
using ProjectTracker.Shared.Models.Login;

namespace ProjectTracker.Client.Services
{
    public interface IAuthService
    {
        Task Register(AccountRegistrationRequest request);
        Task Login(LoginRequest request);
    }
}
