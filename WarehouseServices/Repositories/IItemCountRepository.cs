using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Repositories
{
    public interface IItemCountRepository
    {
        IEnumerable<ItemCount> GetBy(ItemCount itemCount);
        IEnumerable<ItemCount> GetAll();
    }
}