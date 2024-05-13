using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.API.Repositories;
using ProjectTracker.API.Services;
using ProjectTracker.Shared.Entities;
using ProjectTracker.Shared.Models.TimeEntry;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryService _timeEntryService;

        public TimeEntryController(ITimeEntryService timeEntryService)
        {
            _timeEntryService = timeEntryService;
        }

        [HttpGet]
        public ActionResult<List<TimeEntryResponse>> GetAllTimeEntries()
        {
            return Ok(_timeEntryService.GetAllTimeEntries());
        }

        [HttpPost]
        public ActionResult<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntry)
        {
            return Ok(_timeEntryService.CreateTimeEntry(timeEntry));
        }
    }
}
