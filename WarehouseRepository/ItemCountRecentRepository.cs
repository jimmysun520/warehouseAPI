using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
// using System.Linq;
// using System.Data;
using System.Collections.Generic;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseRepository
{
    public class ItemCountRecentRepository : IItemCountRecentRepository
    {
        public string _connectionString { get; set; }

        public ItemCountRecentRepository(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("WarehouseDB");

        public IEnumerable<ItemCount> GetAll() => this.GetBy(new ItemCount());

        public IEnumerable<ItemCount> GetBy(ItemCount itemCount)
        {
            using (var context = new SqlConnection(_connectionString))
            {
                var query = @"SELECT TOP (1000) [DWYEAR] AS Year
                        ,[DWEEK] AS Week
                        ,[DC_NUM] AS DistributionCenterId
                        ,[DWSKU] AS Sku
                        ,[F_RECEPIT_DT] AS FirstReceiptDate
                        ,[L_RECEPIT_DT] AS LastReceiptDate
                        ,[L_SHIP_DT]    AS LastShipDate
                        ,[COST]
                        ,[RESERVE_TOT] AS ReservedTotal
                        ,[ONHAND] AS OnHandQuantity
                        ,[ALLOCATED_QTY] AS AllocatedQuantity
                        ,[SHIP_UNITS] AS ShipUnits
                        ,[RCPT_UNITS] AS ReceiptUnits
                        ,[AONORD_RTL] AS OnOrderRetail
                        ,[AONORD_UNITS] AS OnOrderUnits
                        ,[OUT_OF_STOCK] AS OutOfStockQuantity
                    FROM [DWPROD].[dbo].[DWF170_DCSKU_Import]
                    WHERE (@sku IS NULL OR [DWSKU] = @sku)
                    ";
                return context.Query<ItemCount>(query, itemCount);
            }
        }
    }
}
