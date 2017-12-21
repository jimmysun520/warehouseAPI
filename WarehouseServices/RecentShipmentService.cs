using System.Collections.Generic;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServices
{
    public class RecentShipmentService : IRecentShipmentService
    {
        private readonly IRecentShipmentRepository repository;

        public RecentShipmentService(IRecentShipmentRepository repo) => repository = repo;

        public IEnumerable<RecentShipment> GetBy(RecentShipment recentShipment) => repository.GetBy(recentShipment);
        public IEnumerable<RecentShipment> GetAll() => repository.GetAll();
    }
}
