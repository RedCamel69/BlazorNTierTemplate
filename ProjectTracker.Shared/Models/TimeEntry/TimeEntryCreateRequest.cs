﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Shared.Models.ProjectTask
{
    public record struct ProjectTaskCreateRequest(int ProjectId, DateTime Start, DateTime? End);
}
