namespace ProjectTracker.Shared.Entities
{
    public class TimeEntry : BaseEntity
    {
        public required string Project { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime? End { get; set; }
    }
}
