using System;
using System.Collections.Generic;

// Dwf170_DcSku (come from 157)

namespace WarehouseServices.Infrastructure
{
    public class ItemCount
    {
        public int? Year { get; set; }
        public int? Week { get; set; }
        public int? DistributionCenterId { get; set; }
        public int? Sku { get; set; }
        public DateTime? FirstReceiptDate { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public DateTime? LastShipDate { get; set; }
        public decimal? Cost { get; set; }
        public int? ReservedTotal { get; set; }
        public int? OnHandQuantity { get; set; }
        public int? AllocatedQuantity { get; set; }
        public int? ShipUnits { get; set; }
        public int? ReceiptUnits { get; set; }
        // public int? LW_UNITS_MIN { get; set; }
        // public int? LW_STORE_MIN { get; set; }
        // public int? LW_NBR_STORES { get; set; }
        // public int? STORE_UNITS_SLS { get; set; }
        public decimal? OnOrderRetail { get; set; } //(from 24)
        public int? OnOrderUnits { get; set; } //(24) sku_on_order_summary
        public int? OutOfStockQuantity { get; set; }
    }
}