using backendMpact.Data;
using backendMpact.Models;
using Microsoft.EntityFrameworkCore;


namespace backendMpact.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return $"User '{user.FullName}' added successfully";
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        // Check if any user exists in the database
        public async Task<bool> AnyUserExists()
        {
            return await _context.Users.AnyAsync();
        }
    }
}
