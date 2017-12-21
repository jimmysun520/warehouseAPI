using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WarehouseRepository;
using WarehouseServices.Repositories;

namespace WarehouseRepository.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterWarehouseRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddScoped<IOrderRepository, OrderRepository>();
            services.TryAddScoped<IStoreRepository, StoreRepository>();
            services.TryAddScoped<IItemRepository, ItemRepository>();
            services.TryAddScoped<IShipmentRepository, ShipmentRepository>();
            services.TryAddScoped<IRecentShipmentRepository, RecentShipmentRepository>();
            services.TryAddScoped<IStoreRepository, StoreRepository>();
            services.TryAddScoped<IItemCountRepository, ItemCountRepository>();
            services.TryAddScoped<IItemCountRecentRepository, ItemCountRecentRepository>();
            // services.TryAddScoped<IDwf160ItemRepository, Dwf160ItemRepository>();
            // services.TryAddScoped<IDwf170DcSkuRepository, Dwf170DcSkuRepository>();
            // services.TryAddScoped<IWmf260Repository, Wmf260Repository>();
            // services.TryAddScoped<IWmf260DistinctStoreRepository, Wmf260DistinctStoreRepository>();
            services.TryAddSingleton(configuration);
            return services;
        }
    }
}
