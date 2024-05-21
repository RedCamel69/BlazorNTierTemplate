using ProjectTracker.Shared.Entities;

namespace ProjectTracker.API.Repositories
{
    public interface IProjectTaskRepository
    {
        Task<ProjectTask?> GetProjectTaskById(int id);
        Task<List<ProjectTask>> GetAllProjectTasks();
        Task<List<ProjectTask>> CreateProjectTask(ProjectTask ProjectTask);
        Task<List<ProjectTask>?> UpdateProjectTask(int id, ProjectTask ProjectTask);
        Task<List<ProjectTask>?> DeleteProjectTask(int id);

        Task<List<ProjectTask>> GetProjectTasksByProject(int projectId);
    }
}
