using Microsoft.EntityFrameworkCore;
using ProductHub_API.Data;
using ProductHub_API.Models;
using ProductHub_API.Repositories.Interfaces;

namespace ProductHub_API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;
        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsersModel?> GetByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task Add(UsersModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
