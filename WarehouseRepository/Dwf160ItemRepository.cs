// using System.Data.SqlClient;
// using Dapper;
// using Microsoft.Extensions.Configuration;
// // using System.Linq;
// // using System.Data;
// using System.Collections.Generic;
// using WarehouseData.Contracts;
// using WarehouseData.Models;
// using WarehouseServices.Repositories;

// namespace WarehouseRepository
// {
//     public class Dwf160ItemRepository : IDwf160ItemRepository
//     {
//         public string _connectionString { get; set; }

//         public Dwf160ItemRepository(IConfiguration configuration) =>
//             _connectionString = configuration.GetConnectionString("WarehouseDB");

//         public IEnumerable<IDwf160Item> GetAll() => this.GetBy(null);

//         public IEnumerable<IDwf160Item> GetBy(int? sku)
//         {
//             var s = sku;
//             using (var context = new SqlConnection(_connectionString))
//             {
//                 var query = @"SELECT TOP (1000) [DW_SKU]
//                         ,[SKU_DESC]
//                         ,[SUBCLASS]
//                         ,[INUM_STATUS]
//                         ,[IBUYER]
//                         ,[IVENDOR1]
//                         ,[ISTK_NUM]
//                         ,[INIT_DATE]
//                         ,[DEACT_DATE]
//                         ,[AVAIL_ATRB]
//                         ,[AVAIL_CODE]
//                         ,[ICAT_MIN]
//                         ,[POS_ITEMTYPE]
//                         ,[IRTL_DO_QTY]
//                         ,[IRTL_DO]
//                         ,[IRTL_QTY]
//                         ,[IWHSE_DO]
//                         ,[ICOST]
//                         ,[PRICE_LEVEL]
//                         ,[REP_TYPE_21]
//                         ,[REP_TYPE_22]
//                         ,[ILRECPT_DATE]
//                         ,[DEPT]
//                         ,[CLASS]
//                         ,[FoodStamp]
//                         ,[Min_1]
//                         ,[Min_2]
//                         ,[Min_3]
//                         ,[Min_4]
//                         ,[Min_5]
//                         ,[Min_6]
//                         ,[ProcessDate]
//                         ,[Max_1]
//                         ,[Max_2]
//                         ,[Max_3]
//                         ,[Max_4]
//                         ,[Max_5]
//                         ,[Max_6]
//                         ,[WDI_SKU]
//                         ,[SpecialBuy]
//                         ,[StorePack]
//                         ,[Link_SKU]
//                         ,[FredsOwnBrand]
//                         ,[Tier_Group]
//                         ,[Deal_Pack_SKU]
//                         ,[MasterPack]
//                         ,[Catalog_Type]
//                         ,[Irtl_Do_Qty2]
//                         ,[Irtl_Do2]
//                         ,[irtl_Qty2]
//                         ,[Irtl_Do_Qty3]
//                         ,[Irtl_Do3]
//                         ,[Irtl_Qty3]
//                         ,[Irtl_Do_Qty4]
//                         ,[Irtl_Do4]
//                         ,[Irtl_Qty4]
//                         ,[Zone_Ind]
//                         ,[Un_Pr_Um]
//                         ,[Un_Pr_Um_Qty]
//                     FROM [DWPROD].[dbo].[DWF160_ITEMFILE]
//                     WHERE (@sku IS NULL OR [DW_SKU] = @sku)
//                     ";
//                 return context.Query<Dwf160Item>(query, new { sku });
//             }
//         }
//     }
// }
