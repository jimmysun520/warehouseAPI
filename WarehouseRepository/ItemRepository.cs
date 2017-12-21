using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseRepository
{
    public class ItemRepository : IItemRepository
    {
        public string _connectionString { get; set; }

        public ItemRepository(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("WarehouseDB");

        public IEnumerable<Item> GetAll() => this.GetBy(new Item());

        public IEnumerable<Item> GetBy(Item item)
        {
            using (var context = new SqlConnection(_connectionString))
            {
                var query = @"SELECT [DW_SKU] AS Sku
                        ,[SKU_DESC] AS Description
                        ,[SUBCLASS] AS Subclass
                        ,[INUM_STATUS] AS Status
                        ,[IVENDOR1] AS Vendor
                        ,[ISTK_NUM] AS StockNumber
                        ,[DEACT_DATE] AS DeactivationDate
                        ,[IRTL_DO] AS RetailPrice
                        ,[IWHSE_DO] AS WarehousePrice
                        ,[ICOST] AS CostPrice
                        ,[PRICE_LEVEL] AS PriceLevel
                        ,[REP_TYPE_21] AS WarehouseReplenishType
                        ,[REP_TYPE_22] AS StoreReplenishType
                        ,[DEPT] AS Department
                        ,[CLASS] AS ItemClass
                        ,[ProcessDate] AS ProcessDate
                        ,[StorePack]
                        ,[Link_SKU] AS LinkSku
                        ,[FredsOwnBrand] AS FredsOwnBrand
                        ,[Tier_Group] AS TierGroup
                        ,[Deal_Pack_SKU] AS DealPackSku
                        ,[MasterPack] AS MasterPack
                        ,[Zone_Ind] AS Zone
                        ,[Un_Pr_Um]
                        ,[Un_Pr_Um_Qty]
                    FROM [DWPROD].[dbo].[DWF160_ITEMFILE]
                    WHERE (@Sku IS NULL OR [DW_SKU] = @Sku)
                    ";
                return context.Query<Item>(query, item);
            }
        }
    }
}
