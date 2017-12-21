using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Contracts
{
    public interface IItemService
    {
        IEnumerable<Item> GetBy(Item item);
        IEnumerable<Item> GetAll();
    }
}