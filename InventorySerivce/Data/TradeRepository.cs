using InventorySerivce.Models;

namespace InventorySerivce.Data
{
    public class TradeRepository : ITradeRepository
    {
        private readonly InventorySerivceContext _context;

        public TradeRepository(InventorySerivceContext context)
        {
            _context = context;
        }

        public IEnumerable<Trade> GetAll()
        {
            return _context.Trade.ToList();
        }

        public Trade GetById(int id)
        {
            return _context.Trade.Find(id);
        }

        public void Add(Trade trade)
        {
            _context.Trade.Add(trade);
        }

        public void Delete(int id)
        {
            var trade = _context.Trade.Find(id);
            if (trade != null)
            {
                _context.Trade.Remove(trade);
            }
        }
    }
}
