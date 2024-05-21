using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Shared.Entities
{
    public class User : IdentityUser
    {       
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
    }
}
