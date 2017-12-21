using System.Collections.Generic;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServices
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository repository;

        public StoreService(IStoreRepository repo) => repository = repo;
        public IEnumerable<Store> GetBy(Store store) => repository.GetBy(store);

        public IEnumerable<Store> GetAll() => repository.GetAll();
    }
}
