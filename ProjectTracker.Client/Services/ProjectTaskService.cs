using ProjectTracker.Shared.Models.ProjectTask;
using Mapster;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ProjectTracker.Client.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly HttpClient _http;
        public List<ProjectTaskResponse> ProjectTasks { get; set; } = new List<ProjectTaskResponse>();

        public event Action? OnChange;

        public ProjectTaskService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetProjectTasksByProject(int projectId)
        {
            List<ProjectTaskResponse>? result = null;
            if (projectId <= 0)
            {
                result = await _http.GetFromJsonAsync<List<ProjectTaskResponse>>("api/ProjectTask");
            }
            else
            {
                result = await _http.GetFromJsonAsync<List<ProjectTaskResponse>>($"api/ProjectTask/project/{projectId}");
            }

            if (result != null)
            {
                ProjectTasks = result;
                OnChange?.Invoke();
            }
        }

        public async Task<ProjectTaskResponse> GetProjectTaskById(int id)
        {
            return await _http.GetFromJsonAsync<ProjectTaskResponse>($"api/ProjectTask/{id}");
        }

        public async Task CreateProjectTask(ProjectTaskRequest request)
        {
            await _http.PostAsJsonAsync("api/ProjectTask/", request.Adapt<ProjectTaskCreateRequest>());
        }

        public async Task UpdateProjectTask(int id, ProjectTaskRequest request)
        {
            await _http.PutAsJsonAsync($"api/ProjectTask/{id}", request.Adapt<ProjectTaskUpdateRequest>());
        }

        public async Task DeleteProjectTask(int id)
        {
            await _http.DeleteAsync($"api/ProjectTask/{id}");
        }
    }
}
