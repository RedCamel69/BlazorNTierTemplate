using ProjectTracker.Shared.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Shared.Models.TimeEntry
{
    public record struct TimeEntryResponse(
            int Id,
            ProjectResponse Project,
            DateTime Start,
            DateTime? End
        );
}
