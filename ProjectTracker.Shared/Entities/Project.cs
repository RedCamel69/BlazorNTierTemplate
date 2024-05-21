using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Shared.Entities
{
    public class Project : SoftDeleteableEntity
    {
        public required string Name { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
        public ProjectDetails? ProjectDetails { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
