using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetBy(Order order);

        IEnumerable<Order> GetAll();
    }
}
