using InventorySerivce.Models;

namespace InventorySerivce.Services.EntityServices
{
    public interface IBotService
    {
        public long AddBot(Bot bot);
        public List<Bot> GetAllBots();
    }
}
