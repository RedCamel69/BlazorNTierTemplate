using ProjectTracker.Shared.Models.TimeEntry;

namespace ProjectTracker.Client.Services
{
    public interface ITimeEntryService
    {
        event Action? OnChange;
        public List<TimeEntryResponse> TimeEntries { get; set; }
        Task GetTimeEntriesByProject(int projectId);
        Task<TimeEntryResponse> GetTimeEntryById(int id);
        Task CreateTimeEntry(TimeEntryRequest request);
        Task UpdateTimeEntry(int id, TimeEntryRequest request);
        Task DeleteTimeEntry(int id);
    }
}
