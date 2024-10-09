using InventorySerivce.Models;
using InventorySerivce.Models.Dtos;

namespace InventorySerivce.Services.EntityServices
{
    public interface ITradeService
    {
        Task<Trade> BuyTrade(BuyTradeDto buyTradeDto);
        Task<bool> SellTrade(SellTradeDto sellTradeDto);
    }
}
