using Azure.Core;
using backendMpact.DTO;
using backendMpact.Models;

namespace backendMpact.Services
{
    public interface IUserService
    {
<<<<<<< HEAD
        Task<string> CreateUser(RegisterRequest request, string addedByEmail);
        Task<bool> UserExists(string email);
        Task<LoginResponse> Login(LoginRequest request);
        Task SeedFirstAdmin();
=======
        Task CreateUser(RegisterRequest request);
        Task<bool> UserExists(string email);
        Task<LoginResponse> Login(LoginRequest request);
>>>>>>> c574684fc32a87db64fc2c3af5d90b6f6f83ce72
    }
}
