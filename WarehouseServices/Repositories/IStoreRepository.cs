using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Repositories
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetBy(Store store);
        IEnumerable<Store> GetAll();
    }
}
