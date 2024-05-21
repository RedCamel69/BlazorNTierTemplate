using Mapster;
using ProjectTracker.API.Repositories;
using ProjectTracker.Shared.Entities;
using ProjectTracker.Shared.Exceptions;
using ProjectTracker.Shared.Models.ProjectTask;

namespace ProjectTracker.API.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _ProjectTaskRepo;

        public ProjectTaskService(IProjectTaskRepository ProjectTaskRepo)
        {
            _ProjectTaskRepo = ProjectTaskRepo;
        }

        public async Task<List<ProjectTaskResponse>> CreateProjectTask(ProjectTaskCreateRequest request)
        {
            var newEntry = request.Adapt<ProjectTask>();
            var result = await _ProjectTaskRepo.CreateProjectTask(newEntry);
            return result.Adapt<List<ProjectTaskResponse>>();
        }

        public async Task<List<ProjectTaskResponse>?> DeleteProjectTask(int id)
        {
            var result = await _ProjectTaskRepo.DeleteProjectTask(id);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<List<ProjectTaskResponse>>();
        }

        public async Task<List<ProjectTaskResponse>> GetAllProjectTasks()
        {
            var result = await _ProjectTaskRepo.GetAllProjectTasks();
            return result.Adapt<List<ProjectTaskResponse>>();
        }

        public async Task<List<ProjectTaskResponse>> GetProjectTasksByProject(int projectId)
        {
            var result = await _ProjectTaskRepo.GetProjectTasksByProject(projectId);           
            return result.Adapt<List<ProjectTaskResponse>>();
        }

        public async Task<ProjectTaskResponse?> GetProjectTaskById(int id)
        {
            var result = await _ProjectTaskRepo.GetProjectTaskById(id);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<ProjectTaskResponse>();
        }

        public async Task<List<ProjectTaskResponse>?> UpdateProjectTask(int id, ProjectTaskUpdateRequest request)
        {
            try
            {
                var updatedEntry = request.Adapt<ProjectTask>();
                var result = await _ProjectTaskRepo.UpdateProjectTask(id, updatedEntry);
                return result.Adapt<List<ProjectTaskResponse>>();
            }
            catch (EntityNotFoundException)
            {
                return null;
            }
        }
    }
}