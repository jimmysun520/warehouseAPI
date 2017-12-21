using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Repositories
{
    public interface IRecentShipmentRepository
    {
        IEnumerable<RecentShipment> GetBy(RecentShipment recentShipment);

        IEnumerable<RecentShipment> GetAll();
    }
}
