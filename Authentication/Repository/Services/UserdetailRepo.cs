using Authentication.Models;
using Authentication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository.Services
{
    public class UserdetailRepo : IRepo<int, Userdetail>
    {
        private readonly UserDBContext _context;
        private readonly ILogger<UserdetailRepo> _logger;

        public UserdetailRepo(UserDBContext context, ILogger<UserdetailRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Userdetail?> Add(Userdetail item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Userdetail?> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<Userdetail?> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == key);
            return user;
        }

        public async Task<ICollection<Userdetail>?> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            if (users.Count > 0)
                return users;
            return null;
        }

        public async Task<Userdetail?> Update(Userdetail item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                user.Role = item.Role;
                user.PasswordHash = item.PasswordHash;
                user.PasswordKey = item.PasswordKey;
                user.Status = item.Status;
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
