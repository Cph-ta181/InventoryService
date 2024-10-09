using InventorySerivce.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySerivce.Data
{
    public class BotRepository : IBotRepository
    {
        private readonly InventorySerivceContext _context;

        public BotRepository(InventorySerivceContext context)
        {
            _context = context;
        }

        public List<Bot> GetAll()
        {
            return _context.Bot.ToList();
        }

        public Bot GetById(long id)
        {
            return _context.Bot.Find(id);
        }

        public void Add(Bot bot)
        {
            _context.Bot.Add(bot);
        }

        public void Delete(long id)
        {
            var bot = _context.Bot.Find(id);
            if (bot != null)
            {
                _context.Bot.Remove(bot);
            }
        }
    }
}
