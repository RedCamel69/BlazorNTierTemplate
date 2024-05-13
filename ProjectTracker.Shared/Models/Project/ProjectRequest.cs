using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Shared.Models.Project
{
    public class ProjectRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the project.")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
