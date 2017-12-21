using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Repositories
{
    public interface IItemRepository
    {
        /// Return a item (per sku) distributed by a DC (per dcCode)
        // IEnumerable<IItem> Item(int sku, string dcCode);  


        IEnumerable<Item> GetAll();  
        IEnumerable<Item> GetBy(Item item);  
    }
}
