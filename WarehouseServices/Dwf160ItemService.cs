// using System.Collections.Generic;
// using WarehouseServices.Contracts;
// using WarehouseData.Contracts;
// using WarehouseServices.Repositories;

// namespace WarehouseServices
// {
//     public class Dwf160ItemService : IDwf160ItemService
//     {
//         private readonly IDwf160ItemRepository repository;

//         public Dwf160ItemService(IDwf160ItemRepository repo)
//         {
//             repository = repo;
//         }
//         public IEnumerable<IDwf160Item> GetBy(int sku)
//         {
//             return repository.GetBy(sku);
//         }
//         public IEnumerable<IDwf160Item> GetAll()
//         {
//             return repository.GetAll();
//         }
//     }
// }
