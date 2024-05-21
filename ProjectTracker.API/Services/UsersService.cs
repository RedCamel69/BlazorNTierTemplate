
using Microsoft.AspNetCore.Identity;

namespace ProjectTracker.API.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;

        public UsersService(UserManager<User> userManager)
        {            
            _userManager = userManager;
        }
        public List<User> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }
       
    }
}
