using System;
using System.Collections.Generic;

// Dwf160_Items
//from 172
namespace WarehouseServices.Infrastructure
{
    public class Item
    {
        public int? Sku { get; set; }
        public string Description { get; set; }
        public string Subclass { get; set; }
        public string Status { get; set; }
        public string Vendor { get; set; }
        public string StockNumber { get; set; } //from 72
        public string DeactivationDate { get; set; } 
        public string RetailPrice { get; set; } //from 160 
        public string WarehousePrice { get; set; }
        public string CostPrice { get; set; }
        public string PriceLevel { get; set; }
        public string WarehouseReplenishType { get; set; }
        public string StoreReplenishType { get; set; }
        public string Department { get; set; }
        public string ItemClass { get; set; }
        public string ProcessDate { get; set; }
        public int? StorePack { get; set; }
        public int? LinkSku { get; set; }
        public string FredsOwnBrand { get; set; }
        public string TierGroup { get; set; }
        public string DealPackSku { get; set; }
        public string MasterPack { get; set; }
        public string Zone { get; set; }
        public string Un_Pr_Um { get; set; }  //from 71 unit price ??
        public string Un_Pr_Um_Qty { get; set; } // from 71
    }
}