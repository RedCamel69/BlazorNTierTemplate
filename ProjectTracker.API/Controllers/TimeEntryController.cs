using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.API.Repositories;
using ProjectTracker.Shared.Entities;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _timeEntryRepo;

        public TimeEntryController(ITimeEntryRepository timeEntryRepo)
        {
            _timeEntryRepo = timeEntryRepo;
        }

        [HttpGet]
        public ActionResult<List<TimeEntry>> GetAllTimeEntries()
        {
            return Ok(_timeEntryRepo.GetAllTimeEntries());
        }

        [HttpPost]
        public ActionResult<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
        {
            return Ok(_timeEntryRepo.CreateTimeEntry(timeEntry));
        }
    }
}
