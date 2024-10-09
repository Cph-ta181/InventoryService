using InventorySerivce.Models;

namespace InventorySerivce.Services.EntityServices
{
    public interface IItemService
    {
        public long AddItem(Item item);
        public Task<List<Item>> GetAllItems();
        public Task<Item> GetItemById(long id);
        public Task<long> GetBotWithFewestItems(List<Bot> bots);
    }
}
