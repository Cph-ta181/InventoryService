using InventorySerivce.Data;
using InventorySerivce.Services.EntityServices;

namespace InventorySerivce.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBotRepository, BotRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ISkinRepository, SkinRepository>();
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<IBotService, BotService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemService, ItemService>();
            //services.AddScoped<ISkinService, SkinService>();
            return services;
        }
    }
}
