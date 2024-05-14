using ProjectTracker.Shared.Models.Login;

namespace ProjectTracker.API.Services
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
