using InventorySerivce.Models;
using InventorySerivce.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace InventorySerivce.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly InventorySerivceContext _context;

        public ItemRepository(InventorySerivceContext context)
        {
            _context = context;
        }

        public Task<List<Item>> GetAll()
        {
            return _context.Item.ToListAsync();
        }

        public Item GetById(long id)
        {
            return _context.Item.Find(id);
        }

        public Item Add(Item item)
        {
            _context.Item.Add(item);
            return item;
        }

        public void Delete(long id)
        {
            var item = _context.Item.Find(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }
        }

        public async Task<long> BotWithFewestItems(List<Bot> bots)
        {
            BotItemCountDto? bot = await _context.Item.GroupBy(i => i.BotId)
                .Select(group => new BotItemCountDto
                {
                    botId = group.Key,
                    count = group.Count()
                })
                .OrderBy(rc => rc.count)   // Order by count ascending
                .FirstOrDefaultAsync();

            if (bot == null)
            {
                Console.WriteLine("Bot is null");
                return _context.Bot.FirstOrDefault().Id;
            }
            return bot.botId;
        }
    }
}
