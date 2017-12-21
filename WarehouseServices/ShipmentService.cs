using System.Collections.Generic;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServices
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository repository;

        public ShipmentService(IShipmentRepository repo) => repository = repo;

        public IEnumerable<Shipment> GetBy(Shipment shipment) => repository.GetBy(shipment);
        public IEnumerable<Shipment> GetAll() => repository.GetAll();
    }
}
