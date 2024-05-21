using ProjectTracker.Shared.Models.ProjectTask;

namespace ProjectTracker.API.Services
{
    public interface IProjectTaskService
    {
        Task<ProjectTaskResponse?> GetProjectTaskById(int id);
        Task<List<ProjectTaskResponse>> GetAllProjectTasks();
        Task<List<ProjectTaskResponse>> CreateProjectTask(ProjectTaskCreateRequest ProjectTask);
        Task<List<ProjectTaskResponse>?> UpdateProjectTask(int id, ProjectTaskUpdateRequest ProjectTask);
        Task<List<ProjectTaskResponse>?> DeleteProjectTask(int id);
        Task<List<ProjectTaskResponse>> GetProjectTasksByProject(int projectId);
    }
}
