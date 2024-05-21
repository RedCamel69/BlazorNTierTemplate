using ProjectTracker.Shared.Entities;
using ProjectTracker.Shared.Exceptions;

namespace ProjectTracker.API.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly DataContext _context;
        private readonly IUserContextService _userContextService;

        public ProjectTaskRepository(DataContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<List<ProjectTask>> CreateProjectTask(ProjectTask ProjectTask)
        {
            var user = await _userContextService.GetUserAsync();
            if (user == null)
            {
                throw new EntityNotFoundException("User was not found.");
            }

            ProjectTask.User = user;

            _context.ProjectTasks.Add(ProjectTask);
            await _context.SaveChangesAsync();

            return await GetAllProjectTasks();
        }

        public async Task<List<ProjectTask>?> DeleteProjectTask(int id)
        {
            var userId = _userContextService.GetUserId();
            if (userId == null)
                return null;

            var dbProjectTask = await _context.ProjectTasks
                .FirstOrDefaultAsync(t => t.Id == id && t.User.Id == userId);
            if (dbProjectTask is null)
            {
                return null;
            }

            _context.ProjectTasks.Remove(dbProjectTask);
            await _context.SaveChangesAsync();

            return await GetAllProjectTasks();
        }

        public async Task<List<ProjectTask>> GetAllProjectTasks()
        {
            var userId = _userContextService.GetUserId();
            if (userId == null)
                return new List<ProjectTask>();

            return await _context.ProjectTasks.Where(t => t.User.Id == userId).ToListAsync();
        }

        public async Task<List<ProjectTask>> GetProjectTasksByProject(int projectId)
        {
            var userId = _userContextService.GetUserId();
            if (userId == null)
            {
                throw new EntityNotFoundException("User was not found.");
            }

            return await _context.ProjectTasks
                .Where(te => te.ProjectId == projectId && te.User.Id == userId)
                .ToListAsync();
        }

        public async Task<ProjectTask?> GetProjectTaskById(int id)
        {
            var userId = _userContextService.GetUserId();
            if (userId == null)
                return null;

            var ProjectTask = await _context.ProjectTasks
                .FirstOrDefaultAsync(t => t.Id == id && t.User.Id == userId);
            return ProjectTask;
        }

        public async Task<List<ProjectTask>> UpdateProjectTask(int id, ProjectTask ProjectTask)
        {
            var userId = _userContextService.GetUserId();
            if (userId == null)
            {
                throw new EntityNotFoundException("User was not found.");
            }

            var dbProjectTask = await _context.ProjectTasks
                .FirstOrDefaultAsync(t => t.Id == id && t.User.Id == userId);
            if (dbProjectTask is null)
            {
                throw new EntityNotFoundException($"Entity with ID {id} was not found.");
            }

            dbProjectTask.ProjectId = ProjectTask.ProjectId;
            dbProjectTask.Start = ProjectTask.Start;
            dbProjectTask.End = ProjectTask.End;
            dbProjectTask.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetAllProjectTasks();
        }
    }
}
