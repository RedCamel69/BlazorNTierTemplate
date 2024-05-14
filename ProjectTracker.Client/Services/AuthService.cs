using ProjectTracker.Shared.Models.Account;
using System.Net.Http.Json;

namespace ProjectTracker.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task Register(AccountRegistrationRequest request)
        {
            await _http.PostAsJsonAsync("api/account", request);
        }
    }
}
