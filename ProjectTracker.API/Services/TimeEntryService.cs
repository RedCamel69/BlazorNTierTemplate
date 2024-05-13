using Mapster;
using ProjectTracker.API.Repositories;
using ProjectTracker.Shared.Entities;
using ProjectTracker.Shared.Models.TimeEntry;

namespace ProjectTracker.API.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly ITimeEntryRepository _timeEntryRepo;

        public TimeEntryService(ITimeEntryRepository timeEntryRepo)
        {
            _timeEntryRepo = timeEntryRepo;
        }

        public List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest request)
        {
            var newEntry = request.Adapt<TimeEntry>();
            var result = _timeEntryRepo.CreateTimeEntry(newEntry);
            return result.Adapt<List<TimeEntryResponse>>();
        }

        public List<TimeEntryResponse> GetAllTimeEntries()
        {
            var result = _timeEntryRepo.GetAllTimeEntries();
            return result.Adapt<List<TimeEntryResponse>>();
        }
    }
}