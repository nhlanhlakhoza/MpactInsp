using Azure.Core;
using backendMpact.DTO;
using backendMpact.Models;

namespace backendMpact.Services
{
    public interface IUserService
    {
        Task<string> CreateUser(RegisterRequest request, string addedByEmail);
        Task<bool> UserExists(string email);
        Task<LoginResponse> Login(LoginRequest request);
        Task SeedFirstAdmin();
    }
}
