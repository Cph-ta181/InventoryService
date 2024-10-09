using InventorySerivce.Data;
using InventorySerivce.Models;
using InventorySerivce.Models.Dtos;
using InventorySerivce.Models.Protobufs;
using InventorySerivce.Services.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq;

namespace InventorySerivce.Services.EntityServices
{
    public class TradeService : ITradeService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITradeRepository _tradeRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ISkinRepository _skinRepository;
        private readonly IBotService _botService;
        private readonly IItemService _itemService;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        private readonly InventorySerivceContext _context;

        public TradeService(IUserRepository userRepository, ITradeRepository tradeRepository, IItemRepository itemRepository, ISkinRepository skinRepository, InventorySerivceContext context, IBotService botService, IItemService itemService, IRabbitMQProducer rabbitMQProducer)
        {
            _userRepository = userRepository;
            _tradeRepository = tradeRepository;
            _itemRepository = itemRepository;
            _skinRepository = skinRepository;
            _botService = botService;
            _itemService = itemService;
            _rabbitMQProducer = rabbitMQProducer;
            _context = context;
        }

        public Task<Trade> BuyTrade(BuyTradeDto buyTradeDto)
        {
            return null;
        }
        public async Task<bool> SellTrade(SellTradeDto sellTradeDto)
        {
            long botId = await BotWithFewestItems();
            var transaction = await _context.Database.BeginTransactionAsync();
            {
                try
                {
                    List<Item> items = new List<Item>();
                    List<SendTradeItemDto> sendTradeItems = new List<SendTradeItemDto>();
                    foreach (SellItemDto i in sellTradeDto.items)
                    {
                        Skin skin = new(i.SkinName, i.ImgUrl, i.WeaponType, i.Weapon);
                        skin = await _skinRepository.AddIfNotExist(skin);
                        
                        Item item = new(i.SteamId, sellTradeDto.userId, botId, skin.Id, 0, i.Price, null);
                        item.Skin = skin;
                        items.Add(_itemRepository.Add(item));

                        sendTradeItems.Add(new SendTradeItemDto {SkinId = skin.Id, ItemSteamId = i.SteamId });
                    }
                    Trade trade = new Trade(sellTradeDto.userId, Status.Creating, DateTime.Now);
                    trade.Items = items;
                    _tradeRepository.Add(trade);

                    SendTradeDto sendTradeDto = new SendTradeDto {TradeId = trade.Id, UserId = sellTradeDto.userId, BotId = botId};
                    sendTradeDto.Items.AddRange(sendTradeItems);

                    _rabbitMQProducer.SendMessage(sendTradeDto, "trade-sell-queue");

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    // Rollback the transaction if any exception occurs
                    await transaction.RollbackAsync();
                    return false;
                    throw;
                }
            }
            return true;
        }

        private async Task<long> BotWithFewestItems()
        {
            List<Bot> bots = _botService.GetAllBots();
            return await _itemRepository.BotWithFewestItems(bots);
        }
    }
}
