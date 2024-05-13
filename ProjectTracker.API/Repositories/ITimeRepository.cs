using ProjectTracker.Shared.Entities;

namespace ProjectTracker.API.Repositories
{
    public interface ITimeEntryRepository
    {
        TimeEntry? GetTimeEntryById(int id);
        List<TimeEntry> GetAllTimeEntries();
        List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry);
        List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry);
        List<TimeEntry>? DeleteTimeEntry(int id);
    }
}
