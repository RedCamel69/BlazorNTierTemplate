using ProjectTracker.Shared.Models.ProjectTask;

namespace ProjectTracker.Client.Services
{
    public interface IProjectTaskService
    {
        event Action? OnChange;
        public List<ProjectTaskResponse> ProjectTasks { get; set; }
        Task GetProjectTasksByProject(int projectId);
        Task<ProjectTaskResponse> GetProjectTaskById(int id);
        Task CreateProjectTask(ProjectTaskRequest request);
        Task UpdateProjectTask(int id, ProjectTaskRequest request);
        Task DeleteProjectTask(int id);
    }
}
