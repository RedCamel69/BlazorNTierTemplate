using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.API.Repositories;
using ProjectTracker.API.Services;
using ProjectTracker.Shared.Entities;
using ProjectTracker.Shared.Models.ProjectTask;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _ProjectTaskService;

        public ProjectTaskController(IProjectTaskService ProjectTaskService)
        {
            _ProjectTaskService = ProjectTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectTaskResponse>>> GetAllProjectTasks()
        {
            return Ok(await _ProjectTaskService.GetAllProjectTasks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTaskResponse>> GetProjectTaskById(int id)
        {
            var result = await _ProjectTaskService.GetProjectTaskById(id);
            if (result is null)
            {
                return NotFound("ProjectTask with the given ID was not found.");
            }
            return Ok(result);
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<List<ProjectTaskResponse>>> GetProjectTasksByProject(int projectId)
        {
            return Ok(await _ProjectTaskService.GetProjectTasksByProject(projectId));
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectTaskResponse>>> CreateProjectTask(ProjectTaskCreateRequest ProjectTask)
        {
            return Ok(await _ProjectTaskService.CreateProjectTask(ProjectTask));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectTaskResponse>>> UpdateProjectTask(int id, ProjectTaskUpdateRequest ProjectTask)
        {
            var result = await _ProjectTaskService.UpdateProjectTask(id, ProjectTask);
            if (result is null)
            {
                return NotFound("ProjectTask with the given ID was not found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectTaskResponse>>> DeleteProjectTask(int id)
        {
            var result = await _ProjectTaskService.DeleteProjectTask(id);
            if (result is null)
            {
                return NotFound("ProjectTask with the given ID was not found.");
            }
            return Ok(result);
        }
    }
}
