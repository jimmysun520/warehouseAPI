using System.Collections.Generic;
using WarehouseServices.Infrastructure;

namespace WarehouseServices.Repositories
{
    public interface IShipmentRepository
    {
        // /// Return a single shipment item of an item (per itemSku) to a store (per storeId) on an Invoice (per invoice)
        // IEnumerable<IShipment> Shipment(decimal sku, int storeId, int invoiceNum);

        // /// return all shipments of an item (per itemSku) to a store (per storeId), on all invoices
        // IEnumerable<IShipment> Shipments(decimal sku, int storeId);


        IEnumerable<Shipment> GetAll();
        IEnumerable<Shipment> GetBy(Shipment shipment);
    }
}
