using backendMpact.Models;

namespace backendMpact.Repositories
{
    public interface IUserRepository
    {
<<<<<<< HEAD
        Task<string> Add(User user);
        Task<User> GetByEmailAsync(string email);
        Task<bool> UserExists(string email);
        Task<bool> AnyUserExists();
=======
        void Add(User user);
        Task<User> GetByEmailAsync(string email);
        Task<bool> UserExists(string email);
   
>>>>>>> c574684fc32a87db64fc2c3af5d90b6f6f83ce72
    }
}

