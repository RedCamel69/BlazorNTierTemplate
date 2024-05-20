using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Shared.Models.Project;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin",AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjects());
        }


        [HttpGet("{skip}/{take}")]
        public async Task<ActionResult<List<ProjectResponse>>> GetAllProjects(int skip, int take)
        {
            return Ok(await _projectService.GetAllProjects(skip, take));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> GetProjectById(int id)
        {
            var result = await _projectService.GetProjectById(id);
            if (result is null)
            {
                return NotFound("Project with the given ID was not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectResponse>>> CreateProject(ProjectCreateRequest project)
        {
            return Ok(await _projectService.CreateProject(project));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectResponse>>> UpdateProject(int id, ProjectUpdateRequest project)
        {
            var result = await _projectService.UpdateProject(id, project);
            if (result is null)
            {
                return NotFound("Project with the given ID was not found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectResponse>>> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProject(id);
            if (result is null)
            {
                return NotFound("Project with the given ID was not found.");
            }
            return Ok(result);
        }
    }
}