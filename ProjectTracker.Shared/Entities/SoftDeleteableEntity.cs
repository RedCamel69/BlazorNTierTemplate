using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Shared.Entities
{
    public class SoftDeleteableEntity : BaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? DateDeleted { get; set; }
    }
}
