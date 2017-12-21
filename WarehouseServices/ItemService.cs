using System.Collections.Generic;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServices
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository repository;
        public ItemService(IItemRepository repo) => repository = repo;

        public IEnumerable<Item> GetBy(Item item) => repository.GetBy(item);
        public IEnumerable<Item> GetAll() => repository.GetAll();
    }
}
