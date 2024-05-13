using ProjectTracker.Shared.Models.Project;

namespace ProjectTracker.API.Services
{
    public interface IProjectService
    {
        Task<ProjectResponse?> GetProjectById(int id);
        Task<List<ProjectResponse>> GetAllProjects();
        Task<List<ProjectResponse>> CreateProject(ProjectCreateRequest project);
        Task<List<ProjectResponse>?> UpdateProject(int id, ProjectUpdateRequest project);
        Task<List<ProjectResponse>?> DeleteProject(int id);
    }
}
