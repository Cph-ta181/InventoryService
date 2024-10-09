using InventorySerivce.Models;

namespace InventorySerivce.Data
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        public ValueTask<User> GetById(long id);
        void Add(User user);
        void Delete(long id);
    }
}
