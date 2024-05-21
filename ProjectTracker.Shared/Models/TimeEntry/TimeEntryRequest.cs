﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Shared.Models.ProjectTask
{
    public class ProjectTaskRequest
    {
        public int ProjectId { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime? End { get; set; }
    }
}
