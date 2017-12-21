using System.Collections.Generic;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServices
{
    public class ItemCountRecentService : IItemCountRecentService
    {
        private readonly IItemCountRecentRepository repository;

        public ItemCountRecentService(IItemCountRecentRepository repo) => repository = repo;

        public IEnumerable<ItemCount> GetBy(ItemCount itemCount) => repository.GetBy(itemCount);
        public IEnumerable<ItemCount> GetAll() => repository.GetAll();
    }
}
