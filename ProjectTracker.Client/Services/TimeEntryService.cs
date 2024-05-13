using ProjectTracker.Shared.Models.TimeEntry;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ProjectTracker.Client.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly HttpClient _http;

        public List<TimeEntryResponse> TimeEntries { get; set; } = new List<TimeEntryResponse>();

        public event Action? OnChange;

        public TimeEntryService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetTimeEntriesByProject(int projectId)
        {
            List<TimeEntryResponse>? result;
            if (projectId <= 0)
            {
                result = await _http.GetFromJsonAsync<List<TimeEntryResponse>>("api/timeentry");
            }
            else
            {
                result = await _http.GetFromJsonAsync<List<TimeEntryResponse>>($"api/timeentry/project/{projectId}");
            }

            if (result != null)
            {
                TimeEntries = result;
                OnChange?.Invoke();
            }
        }
    }
}
