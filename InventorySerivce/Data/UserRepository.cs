using InventorySerivce.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySerivce.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly InventorySerivceContext _context;

        public UserRepository(InventorySerivceContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAll()
        {
            return _context.User.ToListAsync();
        }

        public async ValueTask<User> GetById(long id)
        {
            return await _context.User.FindAsync(id);
        }

        public void Add(User user)
        {
            _context.User.Add(user);
        }

        public void Delete(long id)
        {
            var user = _context.User.Find(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
        }
    }
}
