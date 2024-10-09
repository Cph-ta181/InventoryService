using InventorySerivce.Data;
using InventorySerivce.Models;

namespace InventorySerivce.Services.EntityServices
{
    public class BotService : IBotService
    {
        IBotRepository _botRepository;
        InventorySerivceContext _context;

        public BotService(IBotRepository botRepository, InventorySerivceContext context)
        {
            _botRepository = botRepository;
            _context = context;
        }

        public long AddBot(Bot bot)
        {
            _botRepository.Add(bot);
            _context.SaveChanges();
            return bot.Id;
        }

        public  List<Bot> GetAllBots()
        {
            return _botRepository.GetAll();
        }
    }
}
