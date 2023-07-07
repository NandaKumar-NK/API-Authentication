using Authentication.Models;
using Authentication.Repository.Interface;

namespace Authentication.Repository.Services
{
    public class UserRepo : IRepo<int, user>
    {
        private readonly UserDBContext _context;

        public UserRepo(UserDBContext context)
        {
            _context = context;
        }
        public async Task<user?> Add(user item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task<user?> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<user?> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<user>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<user?> Update(user item)
        {
            throw new NotImplementedException();
        }
    }
}

