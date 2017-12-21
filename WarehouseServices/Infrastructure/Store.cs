using System;
using System.Collections.Generic;

// Dwf165_Store
// from 77

namespace WarehouseServices.Infrastructure
{
    public class Store
    {
        public int? StoreId { get; set; }
        public DateTime? DateOnSword { get; set; }
        public int? Status { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
        // public int? ArState { get; set; }
        public int? Type { get; set; }
        public int? ArCon { get; set; } //account receivable 'Con'
        public int? Region { get; set; }
        // public int? ArSuperCode { get; set; } //super code is district
        public string AccountReceivableDateLastPhysical { get; set; }
        public int? Warehouse { get; set; }
        public int? TotalAreaInFoot { get; set; }
        public int? SalesAreaInFoot { get; set; }
        public int? BackRoomAreaInFoot { get; set; }
        public int? ParkingArea { get; set; }
        public int? InvPerFt { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? CompDate { get; set; }
        public DateTime? LastExpansionDate { get; set; }
        public int? MsiDayCode { get; set; }
        public int? ReplenishCode { get; set; } //might not be replenishment code???
        public string Manager { get; set; }
        // public int? SwdParent { get; set; }
        public double? AreaPopulation { get; set; }
        // public double? PopulationWhitePercent { get; set; }
        // public double? PopulationBlackPercent { get; set; }
        // public double? PopulationOtherPercent { get; set; }
        // public int? CmptAreaFt { get; set; }
        // public int? CmptSalesFt { get; set; }
        // public string CmptOpenDate { get; set; }
        // public int? CmptCode { get; set; }
        public int? ReplenishCycle { get; set; } //??? might not replenishment
    }
}