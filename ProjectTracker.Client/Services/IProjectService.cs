using ProjectTracker.Shared.Models.Project;

namespace ProjectTracker.Client.Services
{
    public interface IProjectService
    {
        event Action? OnChange;
        public List<ProjectResponse> Projects { get; set; }
        Task LoadAllProjects();
    }
}
