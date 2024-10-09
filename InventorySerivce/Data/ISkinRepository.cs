using InventorySerivce.Models;

namespace InventorySerivce.Data
{
    public interface ISkinRepository
    {
        IEnumerable<Skin> GetAll();
        Skin GetById(int id);
        void Add(Skin skin);
        void Delete(int id);
        Task<Skin> AddIfNotExist(Skin skin);
    }
}
