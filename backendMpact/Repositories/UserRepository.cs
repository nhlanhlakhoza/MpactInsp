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

<<<<<<< HEAD
        public async Task<string> Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return $"User '{user.FullName}' added successfully";
        }

=======
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
>>>>>>> c574684fc32a87db64fc2c3af5d90b6f6f83ce72
        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
<<<<<<< HEAD
        // Check if any user exists in the database
        public async Task<bool> AnyUserExists()
        {
            return await _context.Users.AnyAsync();
        }
=======

>>>>>>> c574684fc32a87db64fc2c3af5d90b6f6f83ce72
    }
}
