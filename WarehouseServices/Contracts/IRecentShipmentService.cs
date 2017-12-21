using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Contracts
{
    public interface IRecentShipmentService
    {
        IEnumerable<RecentShipment> GetBy(RecentShipment recentShipment);
        IEnumerable<RecentShipment> GetAll();
    }
}