using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Contracts
{
    public interface IItemCountService
    {
        IEnumerable<ItemCount> GetBy(ItemCount itemCount);
        IEnumerable<ItemCount> GetAll();
    }
}