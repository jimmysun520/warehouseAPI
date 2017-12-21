using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Order> GetBy(Order order);
        IEnumerable<Order> GetAll();
    }
}