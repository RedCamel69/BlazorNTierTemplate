using ProjectTracker.Shared.Entities;

namespace ProjectTracker.API.Repositories
{
    public interface ITimeEntryRepository
    {
        List<TimeEntry> GetAllTimeEntries();
        List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry);
    }
}
