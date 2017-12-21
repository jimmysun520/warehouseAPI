using System;
using System.Collections.Generic;

// Dwf120_Orders
// Try to define: Order -- [An entry in a Invoice(by InvoiceId) made to distribute an Item(by sku) from Distribution Center(by DcCode), to a store(by StoreId)]

namespace WarehouseServices.Infrastructure
{
    public class Order
    {
        public int? Store { get; set; }
        public int? Sku { get; set; }
        public int? OrderDate { get; set; }
        public int? ShipDate { get; set; }
        public int? OrderQuantity { get; set; }
        public int? ShipQuantity { get; set; }
        public int? OrderType { get; set; }
        public int? NofillReason { get; set; }
        public int? RunNumber { get; set; }
        public int? DayCode { get; set; }
        public string ItemDescription { get; set; }
        public int? PickPack { get; set; }
        public int? OrderCase { get; set; }
        public int? LedgerNumber { get; set; }
        public int? LedgerSubAccount { get; set; }
        // public int Order_create120 { get; set; }
        // public int RetailQuantity120 { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? WarehouseSalePrice { get; set; }
        public decimal? Cost { get; set; }
        public int? Invoice { get; set; }
        public int? CaseNumber { get; set; }
        // public int Category_seq120 { get; set; }
        // public int Cat_item_seq120 { get; set; }
        public int? DamageCode { get; set; }
        public int? TaxCode { get; set; }
        public int? ItemType { get; set; }
        public int? CycleNumber { get; set; }
        public int? Downloaded { get; set; }
        public int? Uploaded { get; set; }
        public int? CIMsSwitch { get; set; }
        public int? Backorder { get; set; }
        public int? OnReserve { get; set; }
        public int? WarehouseNumber { get; set; }

        // public string Shipped { get; set; }
        // public int OrderNum { get; set; }
        // public string Day { get; set; }
        // public string OType { get; set; }
        // public string Store { get; set; }
        // public int Ord { get; set; }
        // public int Alloc { get; set; }
        // public int Pic { get; set; }
    }
}