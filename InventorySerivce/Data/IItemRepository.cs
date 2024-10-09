using InventorySerivce.Models;

namespace InventorySerivce.Data
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAll();
        Item GetById(long id);
        Item Add(Item item);
        void Delete(long id);

        public Task<long> BotWithFewestItems(List<Bot> bots);
    }
}
