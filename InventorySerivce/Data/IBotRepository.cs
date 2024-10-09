using InventorySerivce.Models;

namespace InventorySerivce.Data
{
    public interface IBotRepository
    {
        List<Bot> GetAll();
        Bot GetById(long id);
        void Add(Bot bot);
        void Delete(long id);
    }
}
