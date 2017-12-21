using WarehouseServices.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WarehouseServices.DependencyInjection.Extensions
{
    public static class ConfigureServicesCollection
    {
        public static IServiceCollection RegisterWarehouseServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.TryAddScoped<IItemService, ItemService>();
            services.TryAddScoped<IOrderService, OrderService>();
            services.TryAddScoped<IStoreService, StoreService>();
            services.TryAddScoped<IItemCountService, ItemCountService>();
            services.TryAddScoped<IShipmentService, ShipmentService>();
            services.TryAddScoped<IRecentShipmentService, RecentShipmentService>();
            services.TryAddScoped<IItemCountRecentService, ItemCountRecentService>();
            // services.TryAddScoped<IDwf160ItemService, Dwf160ItemService>();
            // services.TryAddScoped<IDwf170DcSkuService, Dwf170DcSkuService>();
            // services.TryAddScoped<IWmf260Service, Wmf260Service>();
            // services.TryAddScoped<IWmf260DistinctStoreService, Wmf260DistinctStoreService>();
            services.TryAddSingleton(configuration);
            return services;
        }
    }
}
