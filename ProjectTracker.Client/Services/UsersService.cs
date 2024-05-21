using ProjectTracker.Shared.Entities;
using ProjectTracker.Shared.Models.Project;
using System.Net.Http.Json;

namespace ProjectTracker.Client.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _http;
        public event Action? OnChange;

        public UsersService(HttpClient http)
        {
            _http = http;
        }
       
        public List<User> Users { get; set ; } = new List<User> ();

       
        public async Task LoadAllUsers()
        {
            var result = await _http.GetFromJsonAsync<List<User>>($"api/users");
            if (result != null)
            {
                Users = result;
                OnChange?.Invoke();
            }
        }
    }
}
