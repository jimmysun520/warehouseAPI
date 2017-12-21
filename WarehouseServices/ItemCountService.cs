using System.Collections.Generic;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServices
{
    public class ItemCountService : IItemCountService
    {
        private readonly IItemCountRepository repository;

        public ItemCountService(IItemCountRepository repo) => repository = repo;

        public IEnumerable<ItemCount> GetBy(ItemCount itemCount) => repository.GetBy(itemCount);
        public IEnumerable<ItemCount> GetAll() => repository.GetAll();
    }
}
