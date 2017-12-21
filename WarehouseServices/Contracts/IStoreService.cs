using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Contracts
{
    public interface IStoreService
    {
        IEnumerable<Store> GetBy(Store store);
        IEnumerable<Store> GetAll();
    }
}