using backendMpact.Models;

namespace backendMpact.Repositories
{
    public interface IUserRepository
    {
        Task<string> Add(User user);
        Task<User> GetByEmailAsync(string email);
        Task<bool> UserExists(string email);
        Task<bool> AnyUserExists();
    }
}

