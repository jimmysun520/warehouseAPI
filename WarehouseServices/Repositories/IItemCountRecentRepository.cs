using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Repositories
{
    public interface IItemCountRecentRepository
    {
        IEnumerable<ItemCount> GetBy(ItemCount itemCount);
        IEnumerable<ItemCount> GetAll();
    }
}