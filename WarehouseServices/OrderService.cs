using System.Collections.Generic;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        public OrderService(IOrderRepository repo) => repository = repo;
        public IEnumerable<Order> GetBy(Order order) => repository.GetBy(order);

        public IEnumerable<Order> GetAll() => repository.GetAll();
    }
}
