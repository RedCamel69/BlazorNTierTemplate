using ProjectTracker.Shared.Models.TimeEntry;

namespace ProjectTracker.API.Services
{
    public interface ITimeEntryService
    {
        List<TimeEntryResponse> GetAllTimeEntries();
        List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest timeEntry);
    }
}
