// using System.Collections.Generic;
// using WarehouseServices.Contracts;
// using WarehouseData.Contracts;
// using WarehouseServices.Repositories;

// namespace WarehouseServices
// {
//     public class Wmf260DistinctStoreService : IWmf260DistinctStoreService
//     {
//         private readonly IWmf260DistinctStoreRepository repository;

//         public Wmf260DistinctStoreService(IWmf260DistinctStoreRepository repo) => repository = repo;
//         public IEnumerable<IWmf260DistinctStore> GetBy(int storeId) => repository.GetBy(storeId);
//         public IEnumerable<IWmf260DistinctStore> GetAll() => repository.GetAll();
//     }
// }
