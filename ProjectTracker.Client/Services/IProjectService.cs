using ProjectTracker.Shared.Models.Project;
using ProjectTracker.Shared.Models.Project;


namespace ProjectTracker.Client.Services
{
    public interface IProjectService
    {
        event Action? OnChange;
        public List<ProjectResponse> Projects { get; set; }
        public List<ProjectResponse> DisplayProjects { get; set; }
        Task LoadAllProjects();
        Task LoadAllProjects(int skip, int? take);
        Task<ProjectResponse> GetProjectById(int id);
        Task CreateProject(ProjectRequest request);
        Task UpdateProject(int id, ProjectRequest request);
        Task DeleteProject(int id);
    }
}
