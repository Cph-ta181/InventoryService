using InventorySerivce.Models;

namespace InventorySerivce.Data
{
    public interface ITradeRepository
    {
        IEnumerable<Trade> GetAll();
        Trade GetById(int id);
        void Add(Trade trade);
        void Delete(int id);
    }
}
