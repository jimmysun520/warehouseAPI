using System;
using System.Collections.Generic;

// Wmf260_Details

namespace WarehouseServices.Infrastructure
{
    public class Shipment
    {
        public int? Store { get; set; }
        public int? Invoice { get; set; }
        public int? TruckDay { get; set; }
        public int? InvoiceDate { get; set; }
        public int? Sku { get; set; }
        public int? Quantity { get; set; }
        public int? ProcessDate { get; set; }
    }
}