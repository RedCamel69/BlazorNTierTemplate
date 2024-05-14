using Blazored.Toast.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ProjectTracker.Shared.Models.Account;
using ProjectTracker.Shared.Models.Login;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace ProjectTracker.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly IToastService _toastService;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http,
            IToastService toastService,
            NavigationManager navigationManager,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _toastService = toastService;
            _navigationManager = navigationManager;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }


        public async Task Login(LoginRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/login", request);
            if (result != null)
            {
                var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
                if (!response.IsSuccessful && response.Error != null)
                {
                    _toastService.ShowError(response.Error);
                }
                else if (!response.IsSuccessful)
                {
                    _toastService.ShowError("An unexpected error occurred.");
                }
                else
                {
                    _toastService.ShowSuccess("Login successful! :)");
                    _navigationManager.NavigateTo("timeentries");
                    if (response.Token != null)
                    {
                        await _localStorage.SetItemAsStringAsync("authToken", response.Token);
                        await _authStateProvider.GetAuthenticationStateAsync();
                    }
                    _navigationManager.NavigateTo("timeentries");
                }

            }
        }


        public async Task Register(AccountRegistrationRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/account", request);
            if (result != null)
            {
                var response = await result.Content.ReadFromJsonAsync<AccountRegistrationResponse>();
                if (!response.IsSuccessful && response.Errors != null)
                {
                    foreach (var error in response.Errors)
                    {
                        _toastService.ShowError(error);
                    }
                }
                else if (!response.IsSuccessful)
                {
                    _toastService.ShowError("An unexpected error occurred.");
                }
                else
                {
                    _toastService.ShowSuccess("Registration successful! You may login now. :)");
                }
            }
        }
    }
}
