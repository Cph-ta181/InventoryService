using InventorySerivce.Data;
using InventorySerivce.Models;

namespace InventorySerivce.Services.EntityServices
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        InventorySerivceContext _context;

        public UserService(IUserRepository userRepository, InventorySerivceContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public long AddUser(User user)
        {
            _userRepository.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public Task<List<User>> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        public async Task<User> GetUserById(long id)
        {
            return await _userRepository.GetById(id);
        }
    }
}
