using InventorySerivce.Models;

namespace InventorySerivce.Services.EntityServices
{
    public interface IUserService
    {
        public long AddUser(User user);
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(long id);
    }
}
