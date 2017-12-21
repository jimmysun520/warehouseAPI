using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Contracts
{
    public interface IShipmentService
    {
        IEnumerable<Shipment> GetBy(Shipment shipment);
        IEnumerable<Shipment> GetAll();
    }
}