using ProjectTracker.Shared.Entities;
using ProjectTracker.Shared.Models.Project;

namespace ProjectTracker.Client.Services
{
    public interface IUsersService
    {
        event Action? OnChange;

        public List<User> Users { get; set; }

        Task LoadAllUsers();
    }
}
