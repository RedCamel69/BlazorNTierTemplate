using ProjectTracker.Shared.Models.Account;

namespace ProjectTracker.API.Services
{
    public interface IAccountService
    {
        Task<AccountRegistrationResponse> RegisterAsync(AccountRegistrationRequest request);

        Task AssignRole(string userName, string roleName);
    }
}
