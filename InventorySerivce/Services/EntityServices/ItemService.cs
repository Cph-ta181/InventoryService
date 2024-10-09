using InventorySerivce.Data;
using InventorySerivce.Models;

namespace InventorySerivce.Services.EntityServices
{
    public class ItemService : IItemService
    {
        IItemRepository _itemRepository;
        InventorySerivceContext _context;

        public ItemService(IItemRepository itemRepository, InventorySerivceContext context)
        {
            _itemRepository = itemRepository;
            _context = context;
        }

        public long AddItem(Item item)
        {
            _itemRepository.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _itemRepository.GetAll();
        }
        public async Task<Item> GetItemById(long id)
        {
            return _itemRepository.GetById(id);
        }

        public async Task<long> GetBotWithFewestItems(List<Bot> bots)
        {
            return await _itemRepository.BotWithFewestItems(bots);
        }
    }
}
